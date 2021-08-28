using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public enum Algoritmo
{
    PerlinNoise, PerlinNoiseSmooth, RandomWalk, SmoothRandomWalk, CavePerlinNoise, CaveRandomWalk,
    DirectionalTunnel, RandomMap, AutomataCelularMoore, AutomataCelularVonNeumann
}

public class Generator : MonoBehaviour
{
    [Header("References")]
    public Tilemap tilemap;
    public TileBase tile;

    [Header("Dimentions")]
    public int width = 130;
    public int height = 11;

    [Header("Seed")]
    public bool randomSeed = true;
    public float seed = 0;

    [Header("Algoritmo")]
    public Algoritmo algoritmo = Algoritmo.PerlinNoise;

    [Header("PerlinNoiseSmooth")]
    public int Intervalo = 2;

    [Header("SmoothRandomWalk")]
    public int MinimoAnchoSeccion = 2;

    [Header("Caves")]
    public bool LosBordesSonMuros = true;

    [Header("CavePerlinNoise")]
    public float Modifire = 0.1f;
    public float OffsetX = 0f;
    public float OffsetY = 0f;

    [Header("CaveRandomWalk")]
    [Range(0, 1)]
    public float PorcentajeAEliminar = 0.25f;

    [Header("DirectionalTunnel")]
    public int MaximumWidth = 4;
    public int MinimumWidth = 1;
    public int MaximumDisplacement = 2;
    [Range(0, 1)]
    public float Aspereza = 0.75f;
    [Range(0, 1)]
    public float Displacement = 0.75f;

    [Header("AutomataCelular")]
    [Range(0, 1)]
    public float PorcentajeDeRelleno = 0.45f;
    public int TotalDePasadas = 3;

    public void GenerarMapa()
    {
        tilemap.ClearAllTiles();
        int[,] map = null;

        if (randomSeed)
        {
            seed = Random.Range(0F, 1000f);
        }

        switch (algoritmo)
        {
            case Algoritmo.PerlinNoise:
                map = Metods.GenerarArray(width = 130, height = 11, true);
                map = Metods.PerlinNoise(map, seed);
                break;
            case Algoritmo.PerlinNoiseSmooth:
                map = Metods.GenerarArray(width = 130, height = 11, true);
                map = Metods.PerlinNoiseSmooth(map, seed, Intervalo);
                break;
            case Algoritmo.RandomWalk:
                map = Metods.GenerarArray(width = 130, height = 11, true);
                map = Metods.RandomWalk(map, seed);
                break;
            case Algoritmo.SmoothRandomWalk:
                map = Metods.GenerarArray(width = 130, height = 11, true);
                map = Metods.SmoothRandomWalk(map, seed, MinimoAnchoSeccion);
                break;
            case Algoritmo.CavePerlinNoise:
                map = Metods.GenerarArray(width = 130, height = 30, false);
                map = Metods.CavePerlinNoise(map, Modifire, LosBordesSonMuros, OffsetX, OffsetY, seed);
                break;
            case Algoritmo.CaveRandomWalk:
                map = Metods.GenerarArray(width = 130, height = 30, false);
                map = Metods.CaveRandomWalk(map, seed, PorcentajeAEliminar, LosBordesSonMuros);
                break;
            case Algoritmo.DirectionalTunnel:
                map = Metods.GenerarArray(width = 40, height = 130, false);
                map = Metods.DirectionalTunnel(map, seed, MinimoAnchoSeccion, MaximumWidth, Aspereza, MaximumDisplacement, Displacement);
                break;
            case Algoritmo.RandomMap:
                map = Metods.RandomGenerateMap(width = 70, height = 40, seed, PorcentajeDeRelleno, LosBordesSonMuros);
                break;
            case Algoritmo.AutomataCelularMoore:
                map = Metods.RandomGenerateMap(width = 70, height = 40, seed, PorcentajeDeRelleno, LosBordesSonMuros);
                map = Metods.AutomataCelularMoore(map, TotalDePasadas, LosBordesSonMuros);
                break;
            case Algoritmo.AutomataCelularVonNeumann:
                map = Metods.RandomGenerateMap(width = 70, height = 20, seed, PorcentajeDeRelleno, LosBordesSonMuros);
                map = Metods.AutomataCelularVonNeumann(map, TotalDePasadas, LosBordesSonMuros);
                break;
        }

        Metods.GenerateMap(map, tilemap, tile);
            
            /*= Metods.GenerarArray(weidth, height, false);
        Metods.GenerateMap(map, tilemap, tile);*/

    }

    public void LimpiarMapa()
    {
        tilemap.ClearAllTiles();
    }
}
