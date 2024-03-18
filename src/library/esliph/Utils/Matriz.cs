using System;
using ArrayNative = System.Collections.Generic;

namespace Library.Esliph.Utils;

public class Matriz<T>
{
    private T[,] matriz { get; set; }
    public Type type { get { return typeof(T); } }
    public int rows => this.matriz.GetLength(0);
    public int columns => this.matriz.GetLength(1);

    public Matriz(int rowsColumn = 0) : this(rowsColumn, rowsColumn) { }
    public Matriz(int rows, int columns) : this(new T[rows, columns]) { }
    public Matriz(T[,] matriz)
    {
        this.matriz = matriz;
    }

    public ArrayNative.List<MatrizCell<T>> GetSequenceLinear(MatrizCoordinate positionInitial, MatrizCoordinate direction)
    {
        return this.GetSequenceLinear(positionInitial, direction, new(this.rows, this.columns));
    }

    public ArrayNative.List<MatrizCell<T>> GetSequenceLinear(MatrizCoordinate positionInitial, MatrizCoordinate direction, MatrizCoordinate positionFinal)
    {
        if (positionInitial.X < 0 || positionInitial.X > this.rows - 1)
        {
            string msg = $"Position initial \"Y\" - {positionInitial.Y} - must be less than limite rows of the matriz and greater than zero";
            throw new Exception(msg);
        }
        if (positionInitial.Y < 0 || positionInitial.Y > this.columns - 1)
        {
            string msg = $"Position initial \"Y\" - {positionInitial.Y} - must be less than limite columns of the matriz and greater than zero";
            throw new Exception(msg);
        }

        ArrayNative.List<MatrizCell<T>> sequenceLinear = new();

        int i = positionInitial.X, j = positionInitial.Y;

        while (i >= 0 && i <= this.rows - 1 && i != positionFinal.X)
        {
            while (j >= 0 && j <= this.columns - 1 && j != positionFinal.Y)
            {
                sequenceLinear.Add(this.GetCell(i, j));

                if (direction.Y > 0) j++;
                else j--;
            }

            if (direction.X > 0) i++;
            else i--;
        }

        return sequenceLinear;
    }

    public Matriz<T> Transpose()
    {
        Matriz<T> matrizTransposed = new(this.columns, this.rows);

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                matrizTransposed.SetValue(j, i, this.matriz[i, j]);
            }
        }

        return matrizTransposed;
    }

    public Matriz<T> Clone()
    {
        Matriz<T> matrizCloned = new(this.rows, this.columns);

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                matrizCloned.SetValue(i, j, this.matriz[i, j]);
            }
        }

        return matrizCloned;
    }

    public void Clear()
    {
        for (int i = 0; i < this.rows; i++)
        {
            Array.Clear(this.GetRow(i), 0, this.rows);
        }
    }

    public T[,] GetMatriz()
    {
        return this.matriz;
    }

    public T[] GetRow(int i)
    {
        T[] row = new T[this.columns];
        for (int j = 0; j < this.columns; j++)
        {
            row[j] = matriz[i, j];
        }

        return row;
    }

    public T[] GetColumn(int j)
    {
        T[] column = new T[this.columns];
        for (int i = 0; i < this.columns; i++)
        {
            column[i] = matriz[i, j];
        }

        return column;
    }

    public MatrizCell<T> GetCell(int i, int j)
    {
        return new(i, j, this.matriz[i, j]);
    }

    public MatrizCell<T> GetCell(MatrizCoordinate coordinate)
    {
        return new(coordinate, this.matriz[coordinate.X, coordinate.Y]);
    }

    public void SetValue(T value)
    {
        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                this.SetValue(i, j, value);
            }
        }
    }

    public void SetValue(int i, int j, T value)
    {
        this.matriz[i, j] = value;
    }

    public void SetValue(MatrizCoordinate coordinate, T value)
    {
        this.matriz[coordinate.X, coordinate.Y] = value;
    }

    public override string ToString()
    {
        string content = "";

        for (int i = 0; i < this.rows; i++)
        {
            for (int j = 0; j < this.columns; j++)
            {
                content += this.GetCell(i, j).ToString();

                if (j != this.columns - 1)
                {
                    content += ", ";
                }
            }
            content += "\n";
        }

        return content;
    }
}

public class MatrizCell<T>
{
    private T value { get; }
    private MatrizCoordinate coordinate { get; }

    public MatrizCell() { }
    public MatrizCell(MatrizCoordinate coordinate, T value)
    {
        this.coordinate = coordinate;
        this.value = value;
    }
    public MatrizCell(int x, int y, T value)
    {
        this.coordinate = new(x, y);
        this.value = value;
    }

    public T GetValue()
    {
        return this.value;
    }

    public MatrizCoordinate GetMatrizCoordinate()
    {
        return this.coordinate;
    }
}

public class MatrizCoordinate
{
    public int X, Y;

    public MatrizCoordinate() { }
    public MatrizCoordinate(int x, int y)
    {
        this.X = x;
        this.Y = y;
    }
    public MatrizCoordinate(int value)
    {
        this.X = value;
        this.Y = value;
    }

    public override string ToString()
    {
        return "{X: " + this.X + ", Y: " + this.Y + "}";
    }
}