using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServices.Models;

namespace WebServices.Services
{
    public class UserServices
    {
        UsersManagerEntities entities = new UsersManagerEntities();

        public bool Create(Users user)
        {
            bool respuesta = false;
            try
            {
                entities.Users.Add(user);
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return respuesta;
        }

        public bool Delete(int id)
        {
            bool respuesta = false;
            try
            {
                Users user = entities.Users.Where(p => p.id == id).First();
                entities.Users.Remove(user);
                entities.SaveChanges();
                respuesta = true;
            }
            catch (Exception e)
            {
                string error = e.Message;
            }
            return respuesta;
        }
    }
}
