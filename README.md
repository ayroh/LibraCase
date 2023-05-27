# LibraCase
 
     GridManager    
     
Takes input from slider when GenerateGrid button is pressed and creates grid according to current Canvas width and height.
You can regenerate grid with clicking button again with different size. Sends all tiles to PuzzleManager as list when Grid created.

    Tile
Tiles act with buttons. When tile is pressed it marks itself as occupied and sends its data to PuzzleManager for checking 
all directions for popping X's.

    PuzzleManager
Singleton class for Tile and GridManager to access whenever needed. There is a recursive function that takes Tile class as
parameter. Adds that tile to foundTiles list and checks all 4 directions for occupied tiles. There is a helper function
uses System.Linq.Find to query with x and y value of tile. When function ended, if foundTiles count is equal or more than
3, then mark all tiles in the list as non-occupied and make that tiles pressable again.

    Misc
Slider range is 3-15. You can increase the range from slider UI if you want to try for more. I did it max 15 for usability.
