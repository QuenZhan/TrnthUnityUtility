# Matrix

## What

A 2-Dimension collection. Useage like below:
```
IMatrix<int> matrix=new ArrayMatrix<int>(width:10,height:10);
matrix[2,2]=3; // set value
var number=matrix[2,2]; // get value : 3

```


## Why 

- Q: Why don't you just use c# 2d array like this `int[,] matrix=new int[10,10]` ?
- A: C# 2D array cannot be serialized in Unity3D.
- Q: ... Why don't you just use normal array like `int[] matrix=new int[10]`, then `var valueAtX_Y=matrix[x+y%width];`
- A: This is it. with a better `IMatrix<int>` look and bunch of extionsion methods.

## But ... why ?

It can be used in Diablo-like inventory system : 