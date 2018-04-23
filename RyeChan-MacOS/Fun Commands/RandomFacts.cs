using Discord;
using Discord.Commands;
using Discord.WebSocket;
using Discord.Rest;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;
using System.Text.RegularExpressions;
using System.Globalization;
using RyeChan_MacOS;

namespace RyeChanMacOS.UtilityCommands
{
    public class RandomFacts : ModuleBase<SocketCommandContext>
    {
        #region Random Facts
        [Command("fact")]
        public async Task fact()
        {
            String[] facts = new String[100];
            Random rnd = new Random();
            int pick = rnd.Next(0, facts.Length);

            #region Facts List
            facts[0] = "Banging your head against a wall burns 150 calories an hour.";
            facts[1] = "In the UK, it is illegal to eat mince pies on Christmas Day!";
            facts[2] = "Pteronophobia is the fear of being tickled by feathers!";
            facts[3] = "When hippos are upset, their sweat turns red.";
            facts[4] = "A flock of crows is known as a murder.";
            facts[5] = "\"Facebook Addiction Disorder\" is a mental disorder identified by Psychologists.";
            facts[6] = "The average woman uses her height in lipstick every 5 years.";
            facts[7] = "Cherophobia is the fear of fun.";
            facts[8] = "Human saliva has a boiling point three times that of regular water.";
            facts[9] = "Billy goats urinate on their own heads to smell more attractive to females.";
            facts[10] = "An eagle can kill a young deer and fly away with it.";
            facts[11] = "Heart attacks are more likely to happen on a Monday.";
            facts[12] = "There is a species of spider called the Hobo Spider.";
            facts[13] = "29th May is officially \"Put A Pillow on Your Fridge Day\".";
            facts[14] = "If you lift a kangaroo’s tail off the ground it can’t hop.";
            facts[15] = "Bananas are curved because they grow towards the sun.";
            facts[16] = "The person who invented the Frisbee was cremated and made into a frisbee after he died!";
            facts[17] = "During your lifetime, you will produce enough saliva to fill two swimming pools.";
            facts[18] = "If Pinocchio says “My Nose Will Grow Now”, it would cause a paradox.";
            facts[19] = "Polar bears can eat as many as 86 penguins in a single sitting (if they lived in the same place).";
            facts[20] = "King Henry VIII slept with a gigantic axe beside him.";
            facts[21] = "Movie trailers were originally shown after the movie, which is why they were called \"trailers\".";
            facts[22] = "If you consistently fart for 6 years & 9 months, enough gas is produced to create the energy of an atomic bomb!";
            facts[23] = "in 2015, more people were killed from injuries caused by taking a selfie than by shark attacks.";
            facts[24] = "The top six foods that make your fart are beans, corn, bell peppers, cauliflower, cabbage and milk!";
            facts[25] = "A lion’s roar can be heard from 5 miles away!";
            facts[26] = "A toaster uses almost half as much energy as a full-sized oven.";
            facts[27] = "A baby spider is called a spiderling.";
            facts[28] = "You cannot snore and dream at the same time.";
            facts[29] = "The following can be read forward and backwards: Do geese see God?";
            facts[30] = "A baby octopus is about the size of a flea when it is born.";
            facts[31] = "A sheep, a duck, and a rooster were the first passengers in a hot air balloon.";
            facts[32] = "In Uganda, 50% of the population is under 15 years of age.";
            facts[33] = "Hitler’s mother considered abortion but the doctor persuaded her to keep the baby.";
            facts[34] = "Arab women can initiate a divorce if their husbands don’t pour coffee for them.";
            facts[35] = "Recycling one glass jar saves enough energy to watch TV for 3 hours.";
            facts[36] = "Catfish are the only animals that naturally have an odd number of whiskers.";
            facts[37] = "Facebook, Skype and Twitter are all banned in China.";
            facts[38] = "95% of people text things they could never say in person.";
            facts[39] = "The Titanic was the first ship to use the SOS signal.";
            facts[40] = "In Poole, \"Pound World\" went out of business because of a store across the road called \"99p Stores\", which was selling the same products but for just 1 pence cheaper!";
            facts[41] = "About 8,000 Americans are injured by musical instruments each year.";
            facts[42] = "The French language has seventeen different words for \"surrender\".";
            facts[43] = "Nearly three percent of the ice in Antarctic glaciers is penguin urine.";
            facts[44] = "Bob Dylan’s real name is Robert Zimmerman.";
            facts[45] = "A crocodile can’t poke its tongue out :p";
            facts[46] = "Sea otters hold hands when they sleep so they don’t drift away from each other.";
            facts[47] = "A small child could swim through the veins of a blue whale.";
            facts[48] = "Bin Laden’s death was announced on 1st May 2011. Hitler’s death was announced on 1st May 1945.";
            facts[49] = "A small child could swim through the veins of a blue whale.";
            facts[50] = "J.K. Rowling chose the unusual name \"Hermione\" so young girls wouldn’t be teased for being nerdy!";
            facts[51] = "Hewlett-Packard’s name was decided in a coin toss.";
            facts[52] = "The total number of steps in the Eiffel Tower are 1665.";
            facts[53] = "The Pokémon Hitmonlee and Hitmonchan are based off of Bruce Lee and Jackie Chan.";
            facts[54] = "An arctophile is a person who collects, or is very fond of teddy bears.";
            facts[55] = "Pirates wore earrings because they believed it improved their eyesight.";
            facts[56] = "Los Angeles’s full name is \"El Pueblo de Nuestra Senora la Reina de los Angeles de Porciuncula.\"";
            facts[57] = "The Twitter bird actually has a name – Larry.";
            facts[58] = "Octopuses have four pairs of arms.";
            facts[59] = "In England, in the 1880’s, \"Pants\" was considered a dirty word.";
            facts[60] = "It snowed in the Sahara desert for 30 minutes on the 18th February 1979.";
            facts[61] = "Every human spent about half an hour as a single cell.";
            facts[62] = "If you leave everything to the last minute… it will only take a minute.";
            facts[63] = "Unlike many other big cats, snow leopards are not aggressive towards humans. There has never been a verified snow leopard attack on a human being.";
            facts[64] = "The first alarm clock could only ring at 4am.";
            facts[65] = "Birds don’t urinate.";
            facts[66] = "Dying is illegal in the Houses of Parliaments – This has been voted as the most ridiculous law by the British citizens.";
            facts[67] = "The most venomous jellyfish in the world is named the Irukandji and is smaller than your fingernail.";
            facts[68] = "The 20th of March is known as Snowman Burning Day.";
            facts[69] = "Slugs have 4 noses.";
            facts[70] = "Panphobia is the fear of everything… which is a pretty unlucky phobia to have.";
            facts[71] = "An apple, potato, and onion all taste the same if you eat them with your nose plugged.";
            facts[72] = "The front paws of a cat are different from the back paws. They have five toes on the front but only four on the back.";
            facts[73] = "A company in Taiwan makes dinnerware out of wheat, so you can eat your plate!";
            facts[74] = "The average person walks the equivalent of twice around the world in a lifetime.";
            facts[75] = "The Bible is the most shoplifted book in the world.";
            facts[76] = "Marco Hort has the world record for fitting 264 straws in his mouth at once!";
            facts[77] = "Mel Blanc – the voice of Bugs Bunny – was allergic to carrots.";
            facts[78] = "California has issued 6 drivers licenses to people named Jesus Christ.";
            facts[79] = "According to Genesis 1:20-22, the chicken came before the egg.";
            facts[80] = "In the Caribbean there are oysters that can climb trees.";
            facts[81] = "Worms eat their own poo.";
            facts[82] = "Squirrels forget where they hide about half of their nuts.";
            facts[83] = "Over 1000 birds a year die from smashing into windows.";
            facts[84] = "The inventor of the Waffle Iron did not like waffles.";
            facts[85] = "George W. Bush was once a cheerleader.";
            facts[86] = "In total, there are 205 bones in the skeleton of a horse.";
            facts[87] = "In 1895 Hampshire police handed out the first ever speeding ticket, fining a man for doing 6mph!";
            facts[88] = "Each year, there are more than 40,000 toilet related injuries in the United States.";
            facts[89] = "Strawberries can also be yellow, green or white. This also affects the taste and some have a similar taste to pineapples.";
            facts[90] = "Mewtwo is a clone of the Pokémon Mew, yet it comes before Mew in the Pokédex.";
            facts[91] = "Every year more than 2500 left-handed people are killed from using right-handed products.";
            facts[92] = "Madonna suffers from garophobia which is the fear of thunder.";
            facts[93] = "In June 2017, the Facebook community reached 2 billion active users. That’s more than a quarter of the world’s population uses Facebook each month.";
            facts[94] = "Samuel L. Jackson requested to have a purple light saber in Star Wars in order for him to accept the part as Mace Windu.";
            facts[95] = "Paraskavedekatriaphobia is the fear of Friday the 13th!";
            facts[96] = "Kleenex tissues were originally used as filters in gas masks.";
            facts[97] = "In 1998, Sony accidentally sold 700,000 camcorders that had the technology to see through people’s clothes. These cameras had special lenses that use infrared light, which allowed you to see through some types of clothing.";
            facts[98] = "During your lifetime, you will spend around thirty-eight days brushing your teeth.";
            facts[99] = "Ronald McDonald is \"Donald McDonald\" in Japan because it makes pronunciation easier for the Japanese. In Singapore he’s known as \"Uncle McDonald\".";
            #endregion

            await Context.Channel.SendMessageAsync(facts[pick]);
        }

        #endregion
    }
}
