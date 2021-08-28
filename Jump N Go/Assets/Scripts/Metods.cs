using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class Metods
{
    /// <summary>
    /// Genera un array bidimencional
    /// </summary>
    /// <param name="width">Ancho del mapa 2D</param>
    /// <param name="height">Alto edl mapa 2D</param>
    /// <param name="empty">Verdadero si queremos iniciarlo todo a cero. Si no, todo se iniciara a 1</param>
    /// <returns>El mapa 2D generado</returns>

    public static int[,] GenerarArray(int width, int height, bool empty)
    {
        int[,] map = new int[width, height];
        for(int x = 0; x < width; x++)
        {
            for(int y = 0; y < height; y++)
            {
                map[x, y] = empty ? 0 : 1;
            }
        }
        return map;
    }

    internal static void GenerarArray(int[,] map, Tilemap tilemap, TileBase tile)
    {
        throw new NotImplementedException();
    }

    public static void GenerateMap(int[,] map, Tilemap tilemap, TileBase tile)
    {
        tilemap.ClearAllTiles();

        for(int x = 0; x <= map.GetUpperBound(0); x++)
        {
            for (int y = 0; y <= map.GetUpperBound(1); y++)
            {
                if(map[x,y] == 1)
                {
                    tilemap.SetTile(new Vector3Int(x, y, 0), tile);
                }
            }
        }
    }

    public static int[,] PerlinNoise(int [,] map, float seed)
    {
        int newPoint;

        float reduction = 0.5f;
        for(int x = 0; x <= map.GetUpperBound(0); x++)
        {
            newPoint = Mathf.FloorToInt((Mathf.PerlinNoise(x, seed) - reduction) * map.GetUpperBound(1));

            newPoint += (map.GetUpperBound(1) / 2);
            for(int y = newPoint; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }

        return map;
    }

    public static int[,] PerlinNoiseSmooth(int[,] map, float seed, int intervalo)
    {
        if (intervalo > 1)
        {
            Vector2Int actualPosition, backPosition;
            List<int> noiseX = new List<int>();
            List<int> noiseY = new List<int>();

            int newPoint, points;

            for(int x = 0; x <= map.GetUpperBound(0) + intervalo; x += intervalo)
            {
                newPoint = Mathf.FloorToInt(Mathf.PerlinNoise(x, seed) * map.GetUpperBound(1));
                noiseY.Add(newPoint);
                noiseX.Add(x);
            }
            points = noiseY.Count;

            for(int i = 1; i < points; i ++)
            {
                actualPosition = new Vector2Int(noiseX[i], noiseY[i]);
                backPosition = new Vector2Int(noiseX[i - 1], noiseY[i - 1]);

                Vector2 diference = actualPosition - backPosition;
                float heightChange = diference.y / intervalo;
                float actualHeight = backPosition.y;

                for(int x = backPosition.x; x <= actualPosition.x && x <= map.GetUpperBound(0); x++)
                {
                    for(int y = Mathf.FloorToInt(actualHeight); y >= 0; y--)
                    {
                        map[x, y] = 1;
                    }
                    actualHeight += heightChange;
                }
            }
        }
        else
        {
            map = PerlinNoise(map, seed);
        }

        return map;
    }

    public static int[,] RandomWalk(int[,] map, float seed)
    {
        UnityEngine.Random.InitState(seed.GetHashCode());

        int backHeight = UnityEngine.Random.Range(0, map.GetUpperBound(1));

        for(int x = 0; x <= map.GetUpperBound(0); x++)
        {
            int nextMovement = UnityEngine.Random.Range(0, 3);

            if(nextMovement == 0 && backHeight < map.GetUpperBound(1))
            {
                backHeight++;
            }else if(nextMovement == 1 && backHeight > 0)
            {
                backHeight--;
            }

            for(int y = backHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }

        return map;
    }

    public static int[,] SmoothRandomWalk(int[,] map, float seed, int minimoAnchoSeccion)
    {
        UnityEngine.Random.InitState(seed.GetHashCode());

        int backHeight = UnityEngine.Random.Range(0, map.GetUpperBound(1));

        int anchoSeccion = 0;

        for (int x = 0; x <= map.GetUpperBound(0); x++)
        {
            if(anchoSeccion >= minimoAnchoSeccion)
            {
                int nextMovement = UnityEngine.Random.Range(0, 3);

                if (nextMovement == 0 && backHeight < map.GetUpperBound(1))
                {
                    backHeight++;
                }
                else if (nextMovement == 1 && backHeight > 0)
                {
                    backHeight--;
                }

                anchoSeccion = 0;
            }

            anchoSeccion++;

            for (int y = backHeight; y >= 0; y--)
            {
                map[x, y] = 1;
            }
        }

        return map;
    }

    public static int[,] CavePerlinNoise(int[,] map, float modifire, bool losBordesSonMuros, float offsetX = 0f, float offsetY = 0f, float seed = 0f)
    {
        int newPoint;
        for(int x = 0; x <= map.GetUpperBound(0); x++)
        {
            for(int y = 0; y <= map.GetUpperBound(1); y++)
            {
                if(losBordesSonMuros && (x == 0 || y == 0 || x == map.GetUpperBound(0) || y == map.GetUpperBound(1)))
                {
                    map[x, y] = 1;
                }
                else
                {
                    newPoint = Mathf.RoundToInt(Mathf.PerlinNoise(x * modifire + offsetX + seed, y * modifire + offsetY + seed));
                    map[x, y] = newPoint;
                }
            }
        }

        return map;
    }

    public static int[,] CaveRandomWalk(int[,] map, float seed, float porcentajeSueloAEliminar, bool losBordesSonMuros = true)
    {
        UnityEngine.Random.InitState(seed.GetHashCode());

        int minimumValue = 0;
        int maximumValueX = map.GetUpperBound(0);
        int maximumValueY = map.GetUpperBound(1);
        int width = map.GetUpperBound(0) + 1;
        int height = map.GetUpperBound(1) + 1;
        if (losBordesSonMuros)
        {
            minimumValue++;
            maximumValueX--;
            maximumValueY--;
            width -= 2;
            height -= 2;
        }

        int positionX = UnityEngine.Random.Range(minimumValue, maximumValueX);
        int positionY = UnityEngine.Random.Range(minimumValue, maximumValueY);

        int cantidadDeLosetasAEliminar = Mathf.FloorToInt(width * height * porcentajeSueloAEliminar);

        int losetasEliminadas = 0;

        while(losetasEliminadas < cantidadDeLosetasAEliminar)
        {
            if(map[positionX, positionY] == 1)
            {
                map[positionX, positionY] = 0;
                losetasEliminadas++;
            }

            int randomDirection = UnityEngine.Random.Range(0, 4);
            switch (randomDirection)
            {
                case 0:
                    positionY++;
                    break;
                case 1:
                    positionY--;
                    break;
                case 2:
                    positionX--;
                    break;
                case 3:
                    positionX++;
                    break;
            }
            positionX = Mathf.Clamp(positionX, minimumValue, maximumValueX);
            positionY = Mathf.Clamp(positionY, minimumValue, maximumValueY);
        }

        return map;
    }

    public static int[,] DirectionalTunnel(int[,] map, float seed, int minimumWidth, int maximumWidth, float aspereza, int maximumDisplacement, float displacement)
    {
        int tunnelWidth = 1;

        int x = map.GetUpperBound(0) / 2;

        UnityEngine.Random.InitState(seed.GetHashCode());

        for(int y = 0; y <= map.GetUpperBound(1); y++)
        {
            for(int i = -tunnelWidth; i <= tunnelWidth; i++)
            {
                map[x + i, y] = 0;
            }

            if(UnityEngine.Random.value > 1 - aspereza)
            {
                int widthChange = UnityEngine.Random.Range(-maximumWidth, maximumWidth);
                tunnelWidth += widthChange;

                tunnelWidth = Mathf.Clamp(tunnelWidth, minimumWidth, maximumWidth);
            }

            if(UnityEngine.Random.value > 1 - displacement)
            {
                int xChange = UnityEngine.Random.Range(-maximumDisplacement, maximumDisplacement);
                x += xChange;

                x = Mathf.Clamp(x, maximumWidth + 1, map.GetUpperBound(0) - maximumWidth);
            }
        }

        return map;
    }

    public static int[,] RandomGenerateMap(int width, int height, float seed, float porcentajeDeRelleno, bool losBordesSonMuros)
    {
        UnityEngine.Random.InitState(seed.GetHashCode());

        int[,] map = new int[width, height];

        for(int x = 0; x <= map.GetUpperBound(0); x++)
        {
            for(int y = 0; y <= map.GetUpperBound(1); y++)
            {
                if(losBordesSonMuros && (x == 0 || x == map.GetUpperBound(0) || y == 0 || y == map.GetUpperBound(1)))
                {
                    map[x, y] = 1;
                }
                else
                {
                    map[x, y] = (UnityEngine.Random.value < porcentajeDeRelleno) ? 1 : 0;
                }
            }
        }

        return map;
    }

    public static int CantidadDeLosetasVecinas(int[,] map, int x, int y, bool incluirDiagonales)
    {
        int totalLosetas = 0;

        for(int vecinoX = x - 1; vecinoX <= x + 1; vecinoX++)
        {
            for(int vecinoY = y - 1; vecinoY <= y + 1; vecinoY++)
            {
                if(vecinoX >= 0 && vecinoX <= map.GetUpperBound(0) && vecinoY >= 0 && vecinoY <= map.GetUpperBound(1))
                {
                    if((vecinoX != x || vecinoY != y) && (incluirDiagonales || (vecinoX == x || vecinoY == y)))
                    {
                        totalLosetas += map[vecinoX, vecinoY];
                    }
                }
            }
        }

        return totalLosetas;
    }

    public static int[,] AutomataCelularMoore(int[,] map, int totalDePasadas, bool losBordesSonMuros)
    {
        for(int i = 0; i < totalDePasadas; i++)
        {
            for (int x = 0; x <= map.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= map.GetUpperBound(1); y++)
                {
                    int losetasVecinas = CantidadDeLosetasVecinas(map, x, y, true);

                    if(losBordesSonMuros && (x == 0 || x == map.GetUpperBound(0) || y == 0 || y == map.GetUpperBound(1)))
                    {
                        map[x, y] = 1;
                    }

                    else if(losetasVecinas > 4)
                    {
                        map[x, y] = 1;
                    }else if(losetasVecinas < 4)
                    {
                        map[x, y] = 0;
                    }
                }
            }
        }
        return map;
    }

    public static int[,] AutomataCelularVonNeumann(int[,] map, int totalDePasadas, bool losBordesSonMuros)
    {
        for (int i = 0; i < totalDePasadas; i++)
        {
            for (int x = 0; x <= map.GetUpperBound(0); x++)
            {
                for (int y = 0; y <= map.GetUpperBound(1); y++)
                {
                    int losetasVecinas = CantidadDeLosetasVecinas(map, x, y, false);

                    if (losBordesSonMuros && (x == 0 || x == map.GetUpperBound(0) || y == 0 || y == map.GetUpperBound(1)))
                    {
                        map[x, y] = 1;
                    }

                    else if (losetasVecinas > 2)
                    {
                        map[x, y] = 1;
                    }
                    else if (losetasVecinas < 2)
                    {
                        map[x, y] = 0;
                    }
                }
            }
        }
        return map;
    }
}
