
using UnityEngine;
using AdaptorPattern;

namespace StrategyPattern
{
    public class DuckSimolator : MonoBehaviour
    {
        Duck redHead=new RedHeadDuck();
        ITurkey turkey = new WildTurkey();
        Duck turkeyAdaptor;

        void Start()
        {
        turkeyAdaptor = new TurkeyAdaptor(turkey);
            test(turkeyAdaptor);
          //  test(redHead);


        }

        private void test(Duck duck)
        {
            duck.performQuack();
            duck.performFly();
            duck.display();
        }

    }
}
