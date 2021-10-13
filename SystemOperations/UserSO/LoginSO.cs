using Domain;
using Domen;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemOperations.UserSO
{
    public class LoginSO : SystemOperationBase
    {
        public User Result { get; private set; }
        protected override void ExecuteOperation(IEntity entity)
        {
            User user = (User)entity;
            foreach (User u in repository.GetAll(new User()))
            {
                if (u.Username == user.Username && u.Password == user.Password)
                {
                    user.Name = u.Name;
                    user.LastName = u.LastName;
                    Result =user;
                }
            }
        }
    }
}
