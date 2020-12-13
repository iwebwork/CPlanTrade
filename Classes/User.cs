using System;

namespace Classes
{
    public class User
    {

        /*public User(string name, string login, string pass)
        {
            this.Name = name;
            this.Login = login;
            this.Password = pass;
        }*/

        public string Name { get; set; }

        public string Login { get; set; }

        public string Password { get; set; }

        private static string error;

        public static string printError()
        {
            return error;
        }

        public static bool IsEqual(User userOne, User userTwo)
        {
            if (userOne == null || userTwo == null) { return false; }

            if (userOne.Login != userTwo.Login)
            {
                error = "Usuario não existe!";
                return false;

            }
            else if (userOne.Password != userTwo.Password)
            {
                error = "Usuario e senha não existem!";
                return false;
            }

            return true;
        }

    }
}
