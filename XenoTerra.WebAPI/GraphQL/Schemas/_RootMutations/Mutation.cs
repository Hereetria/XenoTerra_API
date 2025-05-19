namespace XenoTerra.WebAPI.GraphQL.Schemas._RootMutations
{
    public class Mutation
    {
        public AdminMutation Admin { get; }
        public UserMutation User { get; }

        public Mutation(AdminMutation admin, UserMutation user)
        {
            Admin = admin;
            User = user;
        }
    }
}
