// Austin Dugas
// C00231110
// CMPS 358
// Project #1

// Create queue and stack to represent player 1 and 2, respectively
Queue<Card> player1 = new Queue<Card>();
Stack<Card> player2 = new Stack<Card>();

// Initialize rounds won variable
int player1Rounds = 0;
int player2Rounds = 0;
int houseRounds = 0;

// Initialize games won variables
int player1Games = 0;
int player2Games = 0;
int houseGames = 0;

// Initialize the game counter
int games = 100;

// Initialize the house list
Stack<Card> house = new Stack<Card>();

// Initialize the player's card being played in each round
Card player1Card = new Card();
Card player2Card = new Card();

// Initialize the new deck variable
List<Card> newDeck1 = new List<Card>();
List<Card> newDeck2 = new List<Card>();

// Console write for game winner header
Console.WriteLine("Game Winners:");

// Game loop
while (games != 0)
{
    // Reshuffle the decks and add them to the player's hands
    newDeck1 = AFisherYatesKnuthCardShuffleClass.GetDeck();
    newDeck2 = AFisherYatesKnuthCardShuffleClass.GetDeck();
    
    player1 = new Queue<Card>(newDeck1);
    player2 = new Stack<Card>(newDeck2);
    
    // Round loop
    // Checks if one of the player's hands is empty
    while (player1.Count != 0 && player2.Count != 0)
    {
        // Initialize the card value played during this round
        player1Card = player1.Dequeue();
        player2Card = player2.Pop();
        
        // Check the winners of each round
        if (player1Card.value > player2Card.value)
        {
            player1.Enqueue(player1Card);
            player1.Enqueue(player2Card);
            player1Rounds++;
        } else if (player2Card.value > player1Card.value)
        {
            player2.Push(player1Card);
            player2.Push(player2Card);
            player2Rounds++;
        }
        else
        {
            if (player1Card.suit > player2Card.suit)
            {
                player1.Enqueue(player1Card);
                player1.Enqueue(player2Card);
                player1Rounds++;
            } else if (player2Card.suit > player1Card.suit)
            {
                player2.Push(player1Card);
                player2.Push(player2Card);
                player2Rounds++;
            }
            else
            {
                house.Push(player1Card);
                house.Push(player2Card);
                houseRounds++;
            }
        }
    }
    
    // Check the hands of each player to see who won the current game
    if (player1.Count == 0 && player2.Count == 0)
    {
        Console.Write("H");
        houseGames++;
    } else if (player2.Count == 0)
    {
        if (player1.Count > house.Count)
        {
            Console.Write("1");
            player1Games++;
        }
        else
        {
            Console.Write("H");
            houseGames++;
        }
    } 
    else
    {
        if (player2.Count > house.Count)
        {
            Console.Write("2");
            player2Games++;
        }
        else
        {
            Console.Write("H");
            houseGames++;
        }
    }

    // Reset all hands
    player1.Clear();
    player2.Clear();
    house.Clear();

    // Move on to next game
    games--;
}

Console.WriteLine();
Console.WriteLine();

// Print the total rounds won by each player
Console.WriteLine($"Player 1 won {player1Rounds} rounds");
Console.WriteLine($"Player 2 won {player2Rounds} rounds");
Console.WriteLine($"House won {houseRounds} rounds");

Console.WriteLine();

// Print the total games won by each player
Console.WriteLine($"Player 1 won {player1Games} games");
Console.WriteLine($"Player 2 won {player2Games} games");
Console.WriteLine($"House won {houseGames} games");

// Structure that creates card properties that will be assigned in the shuffle class
struct Card
{
    public int suit;
    public int value;
}

// Class that creates a list that represents a deck and shuffles the cards in the deck
static class AFisherYatesKnuthCardShuffleClass
{
    // Method that creates the deck
    public static List<Card> GetDeck()
    {
        List<Card> deck = new List<Card>();
        for (int s = 1; s < 5; s++)
        {
            for (int v = 1; v < 14; v++)
            {
                int suitvalue = s % 2;
                deck.Add(new Card{suit = suitvalue, value = v});
            }
        }

        Shuffle<Card>(deck);

        return deck;
    }
    
    private static Random random = new Random();

    // Method that shuffles the created deck
    private static void Shuffle<T>(this List<T> list)
    {
        int n = list.Count;
        while (n > 1)
        {
            n--;
            int k = random.Next(n + 1);
            T value = list[k];
            list[k] = list[n];
            list[n] = value;
        }
    }
}
