using XenoTerra.WebAPI.GraphQL.Auth;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class Mutation
    {
        public AdminMutation Admin { get; }
        public UserMutation User { get; }
        public RegisterMutation Register { get; }
        public LoginMutation Login { get; }

        public Mutation(AdminMutation admin, UserMutation user, RegisterMutation register, LoginMutation login)
        {
            Admin = admin;
            User = user;
            Register = register;
            Login = login;
        }
    }
}
