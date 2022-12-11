using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Game : MonoBehaviour
{
    [SerializeField] private PlayerView _playerView;
    [SerializeField] private List<SpawnerTransport> _spawnersTrasports;
    [SerializeField] private Finish _finish;
    [SerializeField] private Menu _menu;

    private List<IPause> _itemsPause;

    private Player _player;

    private void OnEnable()
    {
        _player = new Player(0f);
        _playerView.Init(_player);

        _playerView.OnDie += LoseGame;

        _finish.OnFinish += WinGame;

        InitPauseList();
    }

    private void OnDisable()
    {
        _playerView.OnDie -= LoseGame;

        _finish.OnFinish -= WinGame;
    }

    private void InitPauseList()
    {
        _itemsPause = new List<IPause>();

        _itemsPause.Add(_playerView);

        if(_spawnersTrasports.Count != 0)
        {
            foreach (var spawner in _spawnersTrasports)
            {
                _itemsPause.Add(spawner);
            }
        }
    }

    public void WinGame()
    {
        SetPause();

        _menu.WinMenu();
    }

    public void LoseGame()
    {
        SetPause();

        _menu.LoseMenu();
    }

    public void SetPause()
    {
        if (_itemsPause.Count != 0)
        {
            foreach (var item in _itemsPause)
            {
                item.SetPause();
            }
        }
    }

    public void UnPause()
    {
        if (_itemsPause.Count != 0)
        {
            foreach (var item in _itemsPause)
            {
                item.UnPause();
            }
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}
