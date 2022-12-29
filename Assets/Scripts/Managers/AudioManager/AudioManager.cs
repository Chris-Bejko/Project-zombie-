using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioTrack[] tracks;

    private Hashtable _audioTable; // relationship of audio types (key) and tracks (value)
    private Hashtable _jobTable;   // relationship between audio types (key) and jobs (value)      

    private enum AudioAction
    {
        START,
        STOP,
        RESTART
    }

    [System.Serializable]
    public class AudioObject
    {
        public AudioType type;
        public AudioClip clip;
    }

    [System.Serializable]
    public class AudioTrack
    {
        public SourceType sourceType;
        public int maxNumberOfAudio;
        public AudioSource source;
        public AudioObject[] audio;
    }

    private class AudioJob
    {
        public AudioAction action;
        public AudioType type;
        public bool fade;
        public WaitForSeconds delay;

        public AudioJob(AudioAction _action, AudioType _type, bool _fade, float _delay)
        {
            action = _action;
            type = _type;
            fade = _fade;
            delay = _delay > 0f ? new WaitForSeconds(_delay) : null;
        }
    }

    private void OnEnable()
    {
        Configure();
    }
    private void OnDisable()
    {
        Dispose();
    }
    private void Awake()
    {
        InitVolume();
    }

    private void InitVolume()
    {
        if (PlayerPrefs.GetFloat(SourceType.Music.ToString()) != 0)
        {
            SetVolume(SourceType.Music, PlayerPrefs.GetFloat(SourceType.Music.ToString()));
        }
        SetVolume(SourceType.SFX, PlayerPrefs.GetFloat(SourceType.SFX.ToString()));
    }
    public void PlayAudio(AudioType _type, bool _fade = false, float _delay = 0.0F)
    {
        AddJob(new AudioJob(AudioAction.START, _type, _fade, _delay));
    }

    public void StopAudio(AudioType _type, bool _fade = false, float _delay = 0.0F)
    {
        AddJob(new AudioJob(AudioAction.STOP, _type, _fade, _delay));
    }

    public void RestartAudio(AudioType _type, bool _fade = false, float _delay = 0.0F)
    {
        AddJob(new AudioJob(AudioAction.RESTART, _type, _fade, _delay));
    }

    private void Configure()
    {
        _audioTable = new Hashtable();
        _jobTable = new Hashtable();
        GenerateAudioTable();
        //  GenerateRelationsTable();
    }

    private void Dispose()
    {
        // cancel all jobs in progress
        foreach (DictionaryEntry _kvp in _jobTable)
        {
            Coroutine _job = (Coroutine)_kvp.Value;
            StopCoroutine(_job);
        }
    }

    private void GenerateAudioTable()
    {
        foreach (AudioTrack _track in tracks)
        {
            foreach (AudioObject _obj in _track.audio)
            {
                // do not duplicate keys
                if (_audioTable.ContainsKey(_obj.type))
                {
                    Debug.LogWarning("You are trying to register audio [" + _obj.type + "] that has already been registered.");
                }
                else
                {
                    _audioTable.Add(_obj.type, _track);
                    Debug.LogWarning("Registering audio [" + _obj.type + "]");
                }
            }
        }
    }

    private void AddJob(AudioJob _job)
    {
        // cancel any job that might be using this job's audio source
        RemoveConflictingJobs(_job.type);

        Coroutine _jobRunner = StartCoroutine(RunAudioJob(_job));
        _jobTable.Add(_job.type, _jobRunner);
        Debug.LogWarning("Starting job on [" + _job.type + "] with operation: " + _job.action);

    }

    private void RemoveJob(AudioType _type)
    {
        if (!_jobTable.ContainsKey(_type))
        {
            Debug.LogWarning("Trying to stop a job [" + _type + "] that is not running.");
            return;
        }
        Coroutine _runningJob = (Coroutine)_jobTable[_type];
        StopCoroutine(_runningJob);
        _jobTable.Remove(_type);
    }

    private void RemoveConflictingJobs(AudioType _type)
    {
        // cancel the job if one exists with the same type
        if (_jobTable.ContainsKey(_type))
        {
            RemoveJob(_type);
        }

        // cancel jobs that share the same audio track if max number of audio is met

        AudioType _conflictAudio = AudioType.None;
        AudioTrack _audioTrackNeeded = GetAudioTrack(_type, "Get Audio Track Needed");
        int audioClipsPlaying = 0;
        foreach (DictionaryEntry _entry in _jobTable)
        {
            AudioType _audioType = (AudioType)_entry.Key;
            AudioTrack _audioTrackInUse = GetAudioTrack(_audioType, "Get Audio Track In Use");
            if (_audioTrackInUse.source == _audioTrackNeeded.source)
            {
                if (audioClipsPlaying == 0)
                    _conflictAudio = _audioType;
                audioClipsPlaying++;
            }
        }
        if (audioClipsPlaying > _audioTrackNeeded.maxNumberOfAudio)
        {
            RemoveJob(_conflictAudio);
        }
    }

    private IEnumerator RunAudioJob(AudioJob _job)
    {
        if (_job.delay != null)
            yield return _job.delay;

        AudioTrack _track = GetAudioTrack(_job.type); // track existence should be verified by now
        _track.source.clip = GetAudioClipFromAudioTrack(_job.type, _track);

        float _initial = _track.source.volume;
        float _target = _track.source.volume;
        switch (_job.action)
        {
            case AudioAction.START:
                _track.source.Play();
                break;
            case AudioAction.STOP when !_job.fade:
                _track.source.Stop();
                break;
            case AudioAction.STOP:
                _initial = _target;
                _target = 0f;
                break;
            case AudioAction.RESTART:
                _track.source.Stop();
                _track.source.Play();
                break;
        }

        // fade volume
        if (_job.fade)
        {
            float _duration = 1.0f;
            float _timer = 0.0f;

            while (_timer <= _duration)
            {
                _track.source.volume = Mathf.Lerp(_initial, _target, _timer / _duration);
                _timer += Time.deltaTime;
                yield return null;
            }

            // if _timer was 0.9999 and Time.deltaTime was 0.01 we would not have reached the target
            // make sure the volume is set to the value we want
            _track.source.volume = _target;

            if (_job.action == AudioAction.STOP)
            {
                _track.source.Stop();
            }
        }
        else
        {
            // Yield here so last line doesn't execute until after this function has returned.
            yield return null;
        }

        _jobTable.Remove(_job.type);
    }

    private AudioTrack GetAudioTrack(AudioType _type, string _job = "")
    {
        if (!_audioTable.ContainsKey(_type))
        {
            Debug.LogWarning("You are trying to <color=#fff>" + _job + "</color> for [" + _type + "] but no track was found supporting this audio type.");
            return null;
        }
        return (AudioTrack)_audioTable[_type];
    }

    private AudioClip GetAudioClipFromAudioTrack(AudioType _type, AudioTrack _track)
    {
        foreach (AudioObject _obj in _track.audio)
        {
            if (_obj.type == _type)
            {
                return _obj.clip;
            }
        }
        return null;
    }

    public List<AudioSource> GetAllSources()
    {
        List<AudioSource> list = new();
        foreach (AudioTrack e in tracks)
        {
            list.Add(e.source);
        }
        return list;
    }

    public void SetVolume(SourceType type, float volume)
    {
        foreach (var e in tracks)
        {
            if (e.sourceType == type)
            {
                e.source.volume = volume;
            }
        }
    }

    public float GetVolume(SourceType sourceType, bool fromSource = false)
    {
        float result = 1;
        foreach (var e in tracks)
        {
            if (e.sourceType == sourceType)
                result = fromSource ? e.source.volume : PlayerPrefs.GetFloat(e.sourceType.ToString());
        }

        return result;
    }

    public enum AudioType
    {
        None,
    }

    public enum SourceType
    {
        None,
        Music,
        SFX
    }
}
