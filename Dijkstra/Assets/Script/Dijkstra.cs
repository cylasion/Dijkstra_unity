using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dijkstra{

	const int Max = 1000000;
	private int n, m,s,t;
	private int[][] a;
	private int[] d,trace;
	private bool[] free;

	public Dijkstra(){
		
	}

	public void Prepair(int n,int m,int s,int t){
		this.n = n;
		this.m = m;
		this.s = s;
		this.t = t;
		a = new int[n+1][];
		d = new int[n+1];
		trace = new int[n+1];
		free = new bool[n+1];

		for (int i = 1; i <= n; i++)
		{
			a[i] = new int[n+1];
			for (int j = 1; j <= n; j++)
			{
				if (i == j)
					a[i][j] = 0;
				else
					a[i][j] = Max;
			}
		}

		for (int i =1; i <=n; i++)
			d[i] = Max;
		d[s] = 0;
		for (int i =1; i <= n; i++)
			free[i] = true;
	}


	public void addLine(int u,int v,int k){
		a [u] [v] = k;
		a [v] [u] = k;
	}

	public void DoDijkstra()
	{
		do
		{
			int u = s;
			int min = Max;
			for (int i = 1; i <= n; i++)
			{
				if (free[i] == true && d[i] < min)
				{
					u = i;
					min = d[i];
				}
			}
			if (u == 0 || u == t)
			{
				return;
			}
			free[u] = false;
			for (int v = 1; v <= n; v++)
			{
				if (d[v] > d[u] + a[u][v])
				{
					d[v] = d[u] + a[u][v];
					trace[v] = u;
				}
			}
		}
		while (true);

	}

	public void UpdateResult(List<MapLocation> list,int s,int t)
	{
		Debug.Log ("Updating resurlt ......");
		int u = t;
		do {
			int k = trace [u];
			ChangeColor (list, u, k);
			u = k;
		} while(u != s);

	}

	private void ChangeColor(List<MapLocation> list,int u,int v){
		int n = PointScript.NodeCount;
		for(int i =0; i< n; i++){
			if( (list[i].id_A == u && list[i].id_B==v) || (list[i].id_A == v && list[i].id_B== u)){
				LineRenderer render = list [i].line;
				render.SetColors (Color.cyan, Color.cyan);
			}
		}
	}
	 
}
