using UnityEngine;

namespace Challenge
{
    public abstract class camera
    {
        protected IshareBahavior ishareBahavior;

        public camera()
        {
        }

        public void setShareBtn(IshareBahavior ib)
        {
            ishareBahavior = ib;
        }

        public void ImplementShareBehavior()
        {
            ishareBahavior.share();
        }


        public void Take()
        {
            Debug.Log("I took a Image");

        }
        public void Save()
        {
            Debug.Log("save Image");
        }
        public abstract void Edit();

        
    }
}
