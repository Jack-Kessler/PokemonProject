using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace SnorlaxAPI
{
    public class SnorlaxAPI
    {
        public static void PokemonMovesGenerator()
        {
            while (true)
            {
                var client = new HttpClient();
                Console.WriteLine();
                Console.WriteLine("Please enter the name of the Pokemon:");
                string pokemonName = Console.ReadLine().ToLower();
                Console.WriteLine();

                string pokemonURL = $"https://pokeapi.co/api/v2/pokemon/{pokemonName}";

                string pokemonJSONResponse = client.GetStringAsync(pokemonURL).Result;

                //string kanyeActualQuote = JObject.Parse(pokemonJSONResponse).GetValue("quote").ToString();
                //string ronActualQuote = JArray.Parse(pokemonJSONResponse.moves).ToString().Replace('[', ' ').Replace(']', ' ').Trim();
                var answer = JObject.Parse(pokemonJSONResponse);

                //OLD
                //var moves = answer["moves"];
                //var moves0 = moves[0];
                //var moves0Move = moves0["move"];
                //var moves0MoveName = moves0Move["name"];
                //Console.WriteLine($"Displaying Moves: {answer["moves"]}");
                //Console.WriteLine($"Displaying Moves: {moves0MoveName}");

                Console.WriteLine("Displaying Moves");
                for (int i = 0; i < answer["moves"].Count(); i++)
                {
                    var moves = answer["moves"][i]["move"]["name"];
                    Console.WriteLine($"Move {i + 1}: {moves}");
                }
                Console.WriteLine("\n=========================================================\n");

                Console.WriteLine("Would you like to look up another Pokemon's moves? (Type \"yes\" or \"no\")");
                string yesNo = Console.ReadLine();
                if (yesNo == "no")
                {
                    Console.WriteLine("\nHave a nice day!");
                    break;
                }
            }
           
            //Just Background Information - using Snorlax as example

            /*
              {
              "abilities":[...],
              "base_experience": 189,
              "forms": [...],
              "game_indicies": [...}
              "height": 21,
              "held_items": [...],
              "id": 143,
              "is_default": true,
              "location_area_encounters": "https://pokeapi.co/api/v2/pokemon/143/encounters",
              
              "moves": [...], //Line 353    <----IMPORTANT
             
              "name": "Snorlax", 
              etc.
              
              Line 353
              "moves": [{"move": {"name": "mega-punch", "url": "https://pokeapi.co/api/v2/move/5/"},Version_group_details": [...]} //Line 416
              
             */


        }
    }
}
