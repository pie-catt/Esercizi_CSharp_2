using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeUsage
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method,
        AllowMultiple = true, Inherited = false)]
    public class AuthorAttribute : Attribute

    {
        private readonly string _authorName;

        public AuthorAttribute(string name)
        {
            this._authorName = name;
        }

        public string AuthorEmail { get; set; }

        public string GetAuthorName()
        {
            return this._authorName;
        }
    }

    [Author("Carlo")][Author("Andrea")]
    public class Program
    {
        [Author("Pietro", AuthorEmail = "pietro@email.com")]
        public static void Main(string[] args)
        {
            Type type = typeof(Program);
            object[] attributes = type.GetCustomAttributes(false);
            foreach (AuthorAttribute aa in attributes)
                Console.WriteLine(aa.GetAuthorName());
            MethodInfo methodInfo = type.GetMethod("Main");
            var authorAttributes =
                methodInfo.GetCustomAttributes<AuthorAttribute>(false);
            foreach (AuthorAttribute aa in authorAttributes)
                Console.WriteLine("Name = {0}, Email = {1}",
                    aa.GetAuthorName(), aa.AuthorEmail);
            Console.ReadLine();
        }


    }


}
