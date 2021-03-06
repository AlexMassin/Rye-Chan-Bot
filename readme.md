# Rye-Chan V2.7a  

## Welcome to Patch Notes!  

## Additions

*  Added special encryption!
*  Encrypt with `!encrypt {I ate the last slice} key={sorry}`
*  Decrypt with `!decrypt {8t9cq j7kh 8yk 8h7 A} key={sorry}`
*  Added InspiroBot API!
*  Get random quirky quotes generated by an AI with `!inspiro`
*  Added Dad Jokes from icanhazdadjoke.com!
*  Get random awkward dad jokes with `!dadjoke`
*  Added LaTeX Generator!
*  Get simple LaTeX with `!tex {(x+2)^2(x+3)=x^3+7x^2+16x+12}`
*  Added quirky comics from xkcd.com!
*  Get random comics with `!xkcd`
*  Added a translator!
*  Translate between languages with !translate {en} {ja} {Hi, nice to meet you!}
*  Get translation encodings with `!translate langs`
*  Added quoting!
*  Quote a message by copying the message ID and using `!quote {123456789}` **in the same channel**. 
*  Added urban dictionary definitions from urbandictionary.com!
*  Get the best or most upvoted definition with `!urban {yolo}`

## Known Issues
*  `!help` is not updated, will be fixed in a future patch. Refer to this patch note for help.
*  There are some languages missing in `!translate`
*  Certain punctuation and line breaks cause `!translate` to return unwanted bits.
*  `!poll multi` is incomplete.

## Changes

*  New Helper Function to grab proper names (grabs nickname when possible).
*  `!avatar` is now fancy embedded.
*  `!whois` now also returns user ID.
*  Added new shortcut for `!playing`, "l4d2" -> "Left 4 Dead 2"
*  `!morph` now strictly accepts 2 words and also determines is message is too long.
*  New Helper Function for sub stringing tags.

## Current List of Commands

There are 33 commands.  
15 fun commands and 18 utility commands.  
Anything wrapped between `{` and `}` are parameters that are not required to use the command!  
Anything wrapped between `[` and `]` are permissions required to use the command!

### Fun Commands
---

*  `!confess {I ate the last pizza slice}`  
Confess something anonymously and have it posted anonymously. Nothing will be logged.  
I will manually approve confessions to weed out spam and other vulgar content.

*  `!profess {I ate the last pizza slice}[Manage Messages]`
Formats, keeps track of the count of confessions posted, and posts your confession.

*  `!8ball {Are Waffles better than Pancakes?}`  
Ask a yes or no question and watch the eight ball predict an outcome.

*  `!mock {This meme is outdated}`
Formats your message such that every other character is uppercase:  
	`ThIs MeMe Is oUTdAtEd`

*  `!morph {Super} {Stupid}`
Changes a word into another as such:  
	```
	Super
	Supe
	Sup
	Su
	S
	St
	Stu
	Stup
	Stupi
	Stupid
	```

*  `!feels`
Posts a random pepe image, proposing that you may feel that way.

*  `!pick {Waffles, Pancakes, Cereal, Skip Breakfast}`
Picks one of your choices by random.

*  `!fact`
Posts one of one hundred random fun facts.

*  `!say {Something stupid}`
Posts exactly what you say, excluding `@everyone`

*  `!encrypt {I ate the last slice} key={sorry}`
Encrypts your message with a unique algorithm.

*  `!decrypt {8t9cq j7kh 8yk 8h7 A} key={sorry}`
Decrypts an encrypted message with the unique algorithm and sends privately.

*  `!inspiro`
Posts a randomly generated quote. Powered by [inpirobot.me](http://inspirobot.me/)

*  `!dadjoke`
Posts a random dad joke. Powered by [icanhazdadjoke.com](https://icanhazdadjoke.com/)

*  `!xkcd`
Posts a random xkcd comic. Powered by [xkcd.com](https://xkcd.com/)

*  `!urban {yolo}`
Returns the top or most voted definition from urban dictionary. Powered by [urbandictionary.com](https://www.urbandictionary.com/)

### Utility Commands
---

*  `!about`
Posts a little message about this bot, the version, and some credits.

*  `!desc`
Posts the topic of the channel.

*  `!avatar {lXxSomeWeirdo231xXl}`
Returns the link to their avatar, **leave blank to return your avatar**.

*  `!help`
Posts the list of commands with their descriptions, similar to this list.

*  `!conv {num} {baseA} to {baseB}`
Convert your number from decimal, hexadecimal, binary, or octal to another.  
Currently only takes positive numbers, *subject to change*.  
Bases: `DEC`, `HEX`, `OCT`, `BIN`, not case-sensitive.  
	```
	!conv 26 dec to bin
		=> 11010
	```

*  `!page [Manage Messages]`
Moves the chat up to clear messages.

*  `!ping`
Returns the response latency of the bot.

*  `!playing {lol}`
Returns a list of users playing the inquired game. Some shortcuts are available.  
Shortcuts:  
	```
	League of Legends: "lol", "league", "leg"
	Warframe: "wf"
	osu!: "osu"
	Path of Exile: "poe"
	Rocket League: "rl"
	Counter-Strike Global Offensive: "csgo"
	World of Warcraft: "wow"
	Battlefield 1: "bf1", "bf 1"
	Destiny 2: "d2"
	PLAYERUNKNOWN'S BATTLEGROUNDS: "pubg"
	Grand Theft Auto V: "gta v", "gta 5", "gtav", "gta5"
	Doko Doki Literature Club: "ddlc"
	Left 4 Dead 2: "l4d2"
	```  
If a shortcut interferes with another game's name, you can force override like this:
	`!playing wow override name`

*  `!poll help`
Displays help for polls

*  `!poll binary {Are Waffles better than Pancakes?}`
Yes or no poll.

*  `!poll multi {Which is your favourite platform?, PC, PS4, Xbox One}`
Choice poll.   
	`THIS IS WIP... STILL`

*  `!members {Admins}`
Returns a list of people in the inquired role

*  `!trim {1 <= num <= 99}[Manage Messages]`
Bulk deletes messages up to a max of 99 not including the command.

*  `!whois {lXxSomeWeirdo231xXl}`
Returns user data including:  
	```
	Username: Some Weirdo
	Nickname: lXxSomeWeirdo231xXl
	Created: Jan 1, 2012 at 2:15:07 PM (UTC-5:00)[EST]
	Joined: Jan 2, 2012 at 6:21:24 PM (UTC-5:00)[EST]
	Discriminator: #7732
	Playing: League of Legends
	Avatar: [Link] + Preview
	```

*  `!tex {(x+2)^2(x+3)=x^3+7x^2+16x+12}`
Returns LaTeX formatted image. Powered by [latex.codecogs.com](https://latex.codecogs.com/)

*  `!translate {en} {jp} {Hi, nice to meet you!}`
Translates from source language to destination language, your message.

*  `!translate langs`
Returns the list of language encodes for `!translate`

*  `!quote {123456789}`
Quotes a message in the same channel using its ID. You can copy message ID by right clicking and selecting "Copy ID." This requires Developer Mode to be enabled in Discord settings.