using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.UI.Image;

public class PoolManager 
{

     #region Pool
    class Pool // 풀 매니저에서는 여러개의 풀을 갖고있다. 풀매니저가 통합되어 있으면 찾는 것에 시간이 오래걸리기 때문, 딕셔너리로 관리
    {
        public GameObject Original { get; private set; }
        public Transform Root { get; set; }


        Stack<Poolable> _poolStack = new Stack<Poolable>();

        public void Init(GameObject original, int count = 5)
        {
            Original = original;
            Root = new GameObject().transform;
            Root.name = $"{original.name}_Root"; //자식 루트 폴더를 만들어 주는 것임.

            for (int i = 0; i < count; i++)
            {
                Push(Create());
            }

        }

        Poolable Create()
        {
            GameObject go = Object.Instantiate<GameObject>(Original);
            go.name = Original.name; //Clone 이 붙는것을 방지


            return go.GetAddComponent<Poolable>();
        }

        public void Push(Poolable poolable)
        {
            if (poolable == null)
                return;
            poolable.transform.parent = Root;
            poolable.gameObject.SetActive(false);
            poolable.IsUsing = false;

            _poolStack.Push(poolable); //풀스택에다가 넣는다.
        }


        public Poolable Pop(Transform parent)
        {
            Poolable poolable;

            if(_poolStack.Count>0)
                poolable = _poolStack.Pop();

            else
            {
                poolable = Create();
            }

            poolable.gameObject.SetActive(true);  // 게임오브젝트 활성화

            if (parent == null)
            {
                poolable.transform.parent = Managers.Scene.CurrentScene.transform;
            }
            poolable.transform.parent = parent;
            poolable.IsUsing = true;

            return poolable;
        }
    }
    #endregion

    Transform _root; //Transform으로 들고있어도 되고 GameObject로 들고있어도 됨. (GameObject는 Transform 컴포넌트를 무조건 들고 있기 때문에.)
    Dictionary<string,Pool> _pool = new Dictionary<string,Pool>(); // Pool 클래스를 저장하고 있는 딕셔너리 
    public void Init()
    {
        if (_root == null)
            _root = new GameObject { name = "@Pool_root" }.transform; //풀링매니저는 게임이 실행 된 이후로 영구적으로 존재하게 됨.
        Object.DontDestroyOnLoad(_root);
    }
   

    public void CreatePool(GameObject original, int count = 5)
    {
        Pool pool = new Pool();
        pool.Init(original, count);
        pool.Root.parent = _root;

        _pool.Add(original.name, pool);
    }
    public void Push(Poolable poolable) //비활성화 된 상태로 저장 
    {
        string name = poolable.gameObject.name;
        if (_pool.ContainsKey(name) == false)
        {
            GameObject.Destroy(poolable.gameObject);
            return;
        }
            
           

        _pool[name].Push(poolable);

    }

    public Poolable Pop(GameObject original, Transform parent = null) // 활성화 
    {
        if (_pool.ContainsKey(original.name) == false)
            CreatePool(original);
        return _pool[original.name].Pop(parent);
    }

    public GameObject Getoriginal (string name)
    {
        if (_pool.ContainsKey(name) == false)
        {
            return null;
        }

     return _pool[name].Original;

    }


    public void Clear()
    {
        foreach(Transform child in _root)
        {
            GameObject.Destroy(child.gameObject);

        }

        _pool.Clear();
    }
}
