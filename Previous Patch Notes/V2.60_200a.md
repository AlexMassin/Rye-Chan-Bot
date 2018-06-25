# Rye-Chan V2.60_200a  

## Welcome to Patch Notes!  

## Changes

*  Protocol N was removed, specifically due to profanity within the code.  
*  Avatar commands now return gifs if the inquired user is nitro and can have them.
*  `!whois` now accounts for daylight savings changes by converting to local time.
*  `!whois` now also returns user's status.
*  `Phase 2 of Complete OOP Transformation: Helper Functions now simplify code.`

## Bug Fixes

*  Fixed avatar link returning an error for non-gif avatars induced accidentally.

## Current List of Commands

There are 21 commands.  
10 fun commands and 11 utility commands.  
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