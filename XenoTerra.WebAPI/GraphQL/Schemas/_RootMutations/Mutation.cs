using XenoTerra.WebAPI.GraphQL.Auth;

namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class Mutation
    {
        public AdminMutation Admin { get; }
        public UserMutation User { get; }
        public AuthMutation Login { get; }

        public Mutation(AdminMutation admin, UserMutation user, AuthMutation login)
        {
            Admin = admin;
            User = user;
            Login = login;
        }
    }
}
