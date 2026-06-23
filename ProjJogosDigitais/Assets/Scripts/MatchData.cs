public static class MatchData
{
    public static string winnerName = "Samurai";
    public static string p1CharacterName = "Arqueira";
    public static string p2CharacterName = "Bruxo";
    public static int p1Damage = 0;
    public static int p2Damage = 0;
    public static int p1Heal = 0;
    public static int p2Heal = 0;
    public static int p1Mana = 0;
    public static int p2Mana = 0;
    public static int p1Specials = 0;
    public static int p2Specials = 0;
    public static string menuDestination;

    public static void Reset()
    {
        winnerName = "";
        p1Damage = p2Damage = 0;
        p1Heal = p2Heal = 0;
        p1Mana = p2Mana = 0;
        p1Specials = p2Specials = 0;
    }
}