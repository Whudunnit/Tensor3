using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Tensor3
{
    public class Tensor3
    {
        private float[] data;
        private int sizeX;
        private int sizeY;
        private int sizeZ;

        public Tensor3(int sizeX, int sizeY, int sizeZ)
        {
            if (sizeX <= 0 || sizeY <= 0 || sizeZ <= 0)
                throw new ArgumentException("X, Y and Z must be positive integers.");

            this.sizeX = sizeX;
            this.sizeY = sizeY;
            this.sizeZ = sizeZ;

            data = new float[sizeX * sizeY * sizeZ];
        }

        public float GetElement(int x, int y, int z)
        {
            CheckBounds(x, y, z);
            return data[GetIndex(x, y, z)];
        }

        public void SetElement(int x, int y, int z, float value)
        {
            CheckBounds(x, y, z);
            data[GetIndex(x, y, z)] = value;
        }

        public int[] GetSize()
        {
            return new int[] { sizeX, sizeY, sizeZ };
        }

        public void Add(Tensor3 other)
        {
            if (sizeX != other.sizeX || sizeY != other.sizeY || sizeZ != other.sizeZ)
                throw new ArgumentException("Sizes of tensors must match.");

            for (int i = 0; i < data.Length; i++)
            {
                data[i] += other.data[i];
            }
        }

        public Tensor3 AddNew(Tensor3 other)
        {
            if (sizeX != other.sizeX || sizeY != other.sizeY || sizeZ != other.sizeZ)
                throw new ArgumentException("Sizes of tensors must match.");

            Tensor3 result = new Tensor3(sizeX, sizeY, sizeZ);
            for (int i = 0; i < data.Length; i++)
            {
                result.data[i] = data[i] + other.data[i];
            }
            return result;
        }

        public void Resize(int newSizeX, int newSizeY, int newSizeZ)
        {
            if (newSizeX <= 0 || newSizeY <= 0 || newSizeZ <= 0)
                throw new ArgumentException("X, Y and Z must be positive integers.");

            float[] newData = new float[newSizeX * newSizeY * newSizeZ];
            int minX = Math.Min(sizeX, newSizeX);
            int minY = Math.Min(sizeY, newSizeY);
            int minZ = Math.Min(sizeZ, newSizeZ);

            for (int x = 0; x < minX; x++)
            {
                for (int y = 0; y < minY; y++)
                {
                    for (int z = 0; z < minZ; z++)
                    {
                        newData[x + y * newSizeX + z * newSizeX * newSizeY] = GetElement(x, y, z);
                    }
                }
            }
            data = newData;
            sizeX = newSizeX;
            sizeY = newSizeY;
            sizeZ = newSizeZ;
        }

        public void Fill(float value)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] = value;
            }
        }

        private void CheckBounds(int x, int y, int z)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY || z < 0 || z >= sizeZ)
                throw new IndexOutOfRangeException("Index is out of range.");
        }

        private int GetIndex(int x, int y, int z)
        {
            return x + y * sizeX + z * sizeX * sizeY;
        }

        public void PrintAsMatrix()
        {
            Console.WriteLine("Printed Tensor:");
            for (int k = 0; k < sizeZ; k++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        int index = GetIndex(i, j, k);
                        Console.Write(data[index] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        public void PrintZValuesAtXY(int x, int y)
        {
            if (x < 0 || x >= sizeX || y < 0 || y >= sizeY)
                throw new IndexOutOfRangeException("X or Y index is out of range.");

            Console.Write($"Z values at X = {x}, Y = {y}: ");
            for (int i = 0; i < sizeZ; i++)
            {
                int index = GetIndex(x, y, i);
                Console.Write($"{data[index]}" + " ");
            }
        }

        public void PrintYValuesAtXZ(int x, int z)
        {
            if (x < 0 || x >= sizeX || z < 0 || z >= sizeZ)
                throw new IndexOutOfRangeException("X or Z index is out of range.");

            Console.Write($"Y values at X = {x}, Z = {z}: ");
            for (int i = 0; i < sizeY; i++)
            {
                int index = GetIndex(x, i, z);
                Console.Write($"{data[index]}" + " ");
            }
        }

        public void PrintXValuesAtYZ(int y, int z)
        {
            if (z < 0 || z >= sizeZ || y < 0 || y >= sizeY)
                throw new IndexOutOfRangeException("Y or Z index is out of range.");

            Console.Write($"X values at Y = {y}, Z = {z}: ");
            for (int i = 0; i < sizeX; i++)
            {
                int index = GetIndex(i, y, z);
                Console.Write($"{data[index]}" + " ");
            }
        }

        public void ClearData()
        {
            Array.Clear(data, 0, sizeX * sizeY * sizeZ);
        }

        public void InnerArrayZero()
        {
            sizeX = 0;
            sizeY = 0;
            sizeZ = 0;
            data = new float[sizeX * sizeY * sizeZ];
        }

        public float[] GetData()
        {
            return data;
        }

        public void PrintData()
        {
            Console.Write("Inner array: ");
            for (int k = 0; k < sizeZ; k++)
            {
                for (int j = 0; j < sizeY; j++)
                {
                    for (int i = 0; i < sizeX; i++)
                    {
                        int index = GetIndex(i, j, k);
                        Console.Write(data[index] + "," + " ");
                    }
                }
            }
        }

        public void ScalarMultiply(float scalar)
        {
            for (int i = 0; i < data.Length; i++)
            {
                data[i] *= scalar;
            }
        }

        public Tensor3 ScalarMultiplyNew(float scalar)
        {
            Tensor3 scalarTensor = new Tensor3(sizeX, sizeY, sizeZ);
            for (int i = 0; i < data.Length; i++)
            {
                scalarTensor.data[i] = data[i] * scalar;
            }
            return scalarTensor;
        }

        public float GetMaxElement()
        {
            if (data.Length == 0)
                throw new ArgumentException("The Tensor is empty.");

            float maxElement = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] > maxElement)
                {
                    maxElement = data[i];
                }
            }
            Console.WriteLine(maxElement);
            return maxElement;
        }

        public float GetMinElement()
        {
            if (data.Length == 0)
                throw new ArgumentException("The Tensor is empty.");

            float minElement = data[0];
            for (int i = 1; i < data.Length; i++)
            {
                if (data[i] < minElement)
                {
                    minElement = data[i];
                }
            }
            Console.WriteLine(minElement);
            return minElement;
        }
    }
}
