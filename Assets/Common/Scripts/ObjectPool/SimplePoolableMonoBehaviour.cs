public class SimplePoolableMonoBehaviour : PoolableMonoBehaviour
{
    public override void Init()
    {
        gameObject.SetActive(true);
    }

    public override void Sleep()
    {
        gameObject.SetActive(false);
    }
}