Dribbble .NET Library
==============

A C# wrapper for the Dribbble API based on https://github.com/superlogical/dribbble-dotnet

Learn about the Dribbble API at http://dribbble.com/api
 
Examples
--------------

```    
  //Find a player
  var player = Player.Find(1);

  // Find a players shots
  Player player = Player.Find(1);
  PaginatedList<Shot> shots = player.Shots();

  // Find a player followers
  PaginatedList<Player> followers = player.Followers();

  // Find followers of a player
  PaginatedList<Player> following = player.Following();

  // Find a players draftees
  PaginatedList<Player> draftees = player.Draftees();

  // Find a shot
  Shot shot = Shot.Find(21603);

  // Shots by everyone
  PaginatedList<Shot> everyone = Shot.Everyone(perPage:2);
 
  // Debuts shots
  PaginatedList<Shot> debuts = Shot.Debuts(perPage: 2);

  // Popular shots
  PaginatedList<Shot> popular = Shot.Popular(perPage: 2);

  // Find a shots rebounds
  Shot shot = Shot.Find(59714);
  PaginatedList<Shot> rebounds = shot.Rebounds();

  // Comments for a shot
  Shot shot = Shot.Find(59714);
  PaginatedList<Comment> comments = shot.Comments();

  // Checkout the Tests for more!!
```

Credits
--------------

A Mono and .NET library for the Dribbble API, built using C# - By Jake Scott
https://github.com/superlogical/dribbble-dotnet

Hammock is a REST library for .NET that greatly simplifies consuming and wrapping RESTful services.
http://hammock.codeplex.com

Json.NET
http://json.codeplex.com


 
