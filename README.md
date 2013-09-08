Dribbble .NET Library
==============

A C# wrapper for the Dribbble API based on https://github.com/superlogical/dribbble-dotnet

Learn about the Dribbble API at http://dribbble.com/api
 
Examples
--------------

```    
  //Find a player
  var player = await Player.Find(1);

  // Find a players shots
  Player player = await Player.Find(1);
  PaginatedList<Shot> shots = await player.Shots();

  // Find a player followers
  PaginatedList<Player> followers = await player.Followers();

  // Find followers of a player
  PaginatedList<Player> following = await player.Following();

  // Find a players draftees
  PaginatedList<Player> draftees = await player.Draftees();

  // Find a shot
  Shot shot = await Shot.Find(21603);

  // Shots by everyone
  PaginatedList<Shot> everyone = await Shot.Everyone(perPage:2);
 
  // Debuts shots
  PaginatedList<Shot> debuts = await Shot.Debuts(perPage: 2);

  // Popular shots
  PaginatedList<Shot> popular = await Shot.Popular(perPage: 2);

  // Find a shots rebounds
  Shot shot = await Shot.Find(59714);
  PaginatedList<Shot> rebounds = await shot.Rebounds();

  // Comments for a shot
  Shot shot = await Shot.Find(59714);
  PaginatedList<Comment> comments = await shot.Comments();

  // Checkout the Tests for more!!
```

Credits
--------------

A Mono and .NET library for the Dribbble API, built using C# - By Jake Scott
https://github.com/superlogical/dribbble-dotnet

Microsoft HTTP Client Libraries
http://www.nuget.org/packages/Microsoft.Net.Http/

Json.NET
http://json.codeplex.com


 
