using Task3.DoNotChange;
using Task3.Exceptions;

namespace Task3
{
    public class UserTaskController
    {
        private readonly IUserTaskService _taskService;

        public UserTaskController(IUserTaskService taskService)
        {
            _taskService = taskService;
        }

        public bool AddTaskForUser(int userId, string description, IResponseModel model)
        {
            var task = new UserTask(description);

            try
            {
                _taskService.AddTaskForUser(userId, task);
            }
            catch (UserTaskServiceException e)
            {
                model.AddAttribute("action_result", e.Message);
                return false;
            }

            return true;
        }
    }
}