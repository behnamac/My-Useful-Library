using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Fundamental
{
    public interface Transition
    {
        void SetState(States state, string key);
    }
    public interface States
    {
        void JumpTransition(Transition context);
        void FallTransition(Transition context);
        void LandTransition(Transition context);
        void CrouchTransition(Transition context);
    }

    public class StatePattern : MonoBehaviour, Transition
    {
        private States _state = new GroundState();
        private string _key;

        public void DoJump(out string key)
        {
            key = _key;
            _state.JumpTransition(this);
        }
        public void DoFall(out string key)
        {
            key = _key;
            _state.FallTransition(this);

        }
        public void DoLand(out string key)
        {
            key = _key;
            _state.LandTransition(this);

        }
        public void DoCrouch(out string key)
        {
            key = _key;
            _state.CrouchTransition(this);

        }

        public void SetState(States state, string key)
        {
            _state = state;
            _key = key;
        }
    }

    public class GroundState : States
    {
        private string key = "Ground";

        public void CrouchTransition(Transition context)
        {
            var newState = new CrouchingState();
            context.SetState(newState, key);
        }

        public void FallTransition(Transition context)
        {
            var newState = new InAirState();
            context.SetState(newState, key);
        }

        public void JumpTransition(Transition context)
        {
            var newState = new InAirState();
            context.SetState(newState, key);
        }

        public void LandTransition(Transition context)
        {
        }
    }

    public class InAirState : States
    {
        private string key = "InAir";

        public void CrouchTransition(Transition context)
        {
        }

        public void FallTransition(Transition context)
        {
        }

        public void JumpTransition(Transition context)
        {
        }

        public void LandTransition(Transition context)
        {
            var newState = new GroundState();
            context.SetState(newState, key);
        }
    }

    public class CrouchingState : States
    {
        private string key = "Crouching";

        public void CrouchTransition(Transition context)
        {
            var newState = new GroundState();
            context.SetState(newState, key);
        }

        public void FallTransition(Transition context)
        {
            var newState = new InAirState();
            context.SetState(newState, key);
        }

        public void JumpTransition(Transition context)
        {
        }

        public void LandTransition(Transition context)
        {

        }
    }

}
