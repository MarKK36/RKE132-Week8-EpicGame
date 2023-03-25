string folderPath = @"C:\Data";
string heroFile = "Heroes.txt";
string villainFile = "Villains.txt";

string[] heroes = File.ReadAllLines(Path.Combine(folderPath, heroFile));
string[] villains = File.ReadAllLines(Path.Combine(folderPath, villainFile));


//string[] heroes = { "Ant-Man", "Hulk", "Black Panther", "Spider-Man", "Thor" };
//string[] villains = { "Thanos", "Whiplash", "Laufey", "Yellowjacket", "Ikaris" };


string[] weapon = { "gun", "RPG", "bat", "fork", "knife", "sword", "Twisted Tea" };


string hero = GetRandomValueFromArray(heroes);
string heroeWeapon = GetRandomValueFromArray(weapon);
int heroHP = GetCharacterHP(hero); 
int heroStrikeStrength = heroHP;
Console.WriteLine($"Today {hero} ({heroHP}) with {heroeWeapon} saves the day!");

string villain = GetRandomValueFromArray(villains);
string villainWeapon = GetRandomValueFromArray(weapon);
int villainHP = GetCharacterHP(villain);
int villainStrikeStrength = villainHP;
Console.WriteLine($"Today {villain} ({villainHP}) with {villainWeapon} tries to take over the world!");

while(heroHP > 0 && villainHP > 0)
{
    heroHP = heroHP - Hit(villain, villainStrikeStrength);
    villainHP = villainHP - Hit(hero, heroStrikeStrength);
}

Console.WriteLine($"Hero {hero} HP: {heroHP}");
Console.WriteLine($"Villain {villain} HP: {villainHP}");

if (heroHP > 0)
{
    Console.WriteLine($"{hero} saved the day!");
}
else if (villainHP > 0)
{
    Console.WriteLine($"Dark side wins!");
}
else
{
    Console.WriteLine("Draw!");
}
static string GetRandomValueFromArray(string[] somArray)
{
    Random rnd = new Random();
    int randomIndex = rnd.Next(0, somArray.Length);
    string randomStringFromArray = somArray[randomIndex];
    return randomStringFromArray;
}


static int GetCharacterHP(string characterName)
{
    if(characterName.Length < 10)
    {
        return 10;
    }
    else
    {
        return characterName.Length;
    }
}

static int Hit(string characterName, int characterHP)
{
    Random rnd = new Random();
    int strike = rnd.Next(0, characterHP);

    if (strike == 0)
    {
        Console.WriteLine($"{characterName} missed the target!");
    }
    else if (strike == characterHP - 1)
    {
        Console.WriteLine($"{characterName} made a critical hit!");
    }
    else
    {
        Console.WriteLine($"{characterName} hit {strike}!");
    }

return strike;
}