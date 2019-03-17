namespace SimpleTurnBasedGame.Infrastructure
{
    public static class A
    {
        public static PlayerBuilder Player()
        {
            return new PlayerBuilder();
        }

        public static TokenBuilder Token()
        {
            return new TokenBuilder();
        }
    }
}