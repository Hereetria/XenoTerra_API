namespace XenoTerra.WebAPI.GraphQL.Schemas._RootQueries
{
    public class Query
    {
        public AdminQuery Admin { get; }
        public UserQuery User { get; }

        public Query(AdminQuery admin, UserQuery user)
        {
            Admin = admin;
            User = user;
        }
    }
}