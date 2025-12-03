using Mokeb.Domain.Model.Base;
using Mokeb.Domain.Model.Exceptions.FAQExceptions;

namespace Mokeb.Domain.Model.Entities
{
    public class FAQ : BaseEntity<Guid>
    {
        public FAQ(string question, string answer)
        {
            CheckAnswer(answer);
            CheckQuestion(question);

            Question = question;
            Answer = answer;
        }

        public string Question { get; private set; }
        public string Answer { get; private set; }

        #region Behaviors
        public void ChangeAnswer(string answer)
        {
            CheckAnswer(answer);
            Answer = answer;
        }
        #endregion
        #region Behaviors
        public void CheckQuestion(string question)
        {
            if (string.IsNullOrEmpty(Question))
                throw new QuestionIsInvalidException();
        }
        public void CheckAnswer(string answer)
        {
            if (string.IsNullOrEmpty(Answer))
                throw new AnswerIsInvalidException();
        }
        #endregion
    }
}
