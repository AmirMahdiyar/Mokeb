using Mokeb.Domain.Model.Enums;

namespace Mokeb.Domain.Model.Base
{
    public abstract class Request : BaseEntity<Guid>
    {
        public uint MaleCount { get; protected set; }
        public uint FemaleCount { get; protected set; }
        public DateTime TimeOfEntrance { get; protected set; }
        public DateTime TimeOfExit { get; protected set; }
        public State State { get; protected set; } = State.InView;


        #region Behaviors
        public virtual void ChangeToAccepted()
        {
            State = State.Accepted;
        }
        public virtual void ChangeToRejected()
        {
            State = State.Rejected;
        }
        public virtual void ChangeToInView()
        {
            State = State.InView;
        }
        #endregion
    }
}
