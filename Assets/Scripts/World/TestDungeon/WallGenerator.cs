using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class WallGenerator
{
    public static void CreateWalls(HashSet<Vector2Int> floorPositions, TilemapVisualizer tilemapVisualizer)
    {
        var basicWallPositions = FindWallsInDirections(floorPositions, Direction2D.cardinalDirectionsList);
        foreach(var position in basicWallPositions)
        {
            tilemapVisualizer.PaintSingleBasicWall(position);
        }
    }

    private static HashSet<Vector2Int> FindWallsInDirections(HashSet<Vector2Int> floorPositions, List<Vector2Int> directionList)
    {
        HashSet<Vector2Int> wallPostions = new HashSet<Vector2Int>();
        foreach (var position in floorPositions)
        {
            foreach(var direction in directionList)
            {
                var neighborPosition = position + direction;
                if(floorPositions.Contains(neighborPosition) == false)
                    wallPostions.Add(neighborPosition);
            }
        }
        return wallPostions;
    }
}
