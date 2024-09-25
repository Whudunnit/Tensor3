using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Security.Policy;

namespace Tensor3Test
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void Tensor3_GetElement_ReturnsCorrectValue()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(3, 3, 3);
            tensor.SetElement(1, 1, 1, 5);

            float result = tensor.GetElement(1, 1, 1);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Tensor3_SetElement_SetsCorrectValue()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(3, 3, 3);

            tensor.SetElement(1, 1, 1, 5);
            float result = tensor.GetElement(1, 1, 1);

            Assert.AreEqual(5, result);
        }

        [TestMethod]
        public void Tensor3_Resize_ChangesSizeCorrectly()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);

            tensor.Resize(3, 3, 3);
            int[] newSize = tensor.GetSize();

            CollectionAssert.AreEqual(new int[] { 3, 3, 3 }, newSize);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tensor3_Resize_NegativeSize_ThrowsException()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);

            tensor.Resize(-1, 3, 3);
        }

        [TestMethod]
        public void Tensor3_Add_AddsCorrectly()
        {
            Tensor3.Tensor3 tensor1 = new Tensor3.Tensor3(2, 2, 2);
            Tensor3.Tensor3 tensor2 = new Tensor3.Tensor3(2, 2, 2);
            tensor1.Fill(1);
            tensor2.Fill(2);

            tensor1.Add(tensor2);

            for (int i = 0; i < tensor1.GetSize()[0] * tensor1.GetSize()[1] * tensor1.GetSize()[2]; i++)
            {
                Assert.AreEqual(3, tensor1.GetElement(i % tensor1.GetSize()[0], (i / tensor1.GetSize()[0]) % tensor1.GetSize()[1], i / (tensor1.GetSize()[0] * tensor1.GetSize()[1])));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tensor3_Add_DifferentSizeT_ThrowsException()
        {
            Tensor3.Tensor3 tensor1 = new Tensor3.Tensor3(2, 2, 2);
            Tensor3.Tensor3 tensor2 = new Tensor3.Tensor3(3, 3, 3);
            tensor1.Fill(1);
            tensor2.Fill(2);

            tensor1.Add(tensor2);

            for (int i = 0; i < tensor1.GetSize()[0] * tensor1.GetSize()[1] * tensor1.GetSize()[2]; i++)
            {
                Assert.AreEqual(3, tensor1.GetElement(i % tensor1.GetSize()[0], (i / tensor1.GetSize()[0]) % tensor1.GetSize()[1], i / (tensor1.GetSize()[0] * tensor1.GetSize()[1])));
            }
        }

        [TestMethod]
        public void Tensor3_AddNew_AddsCorrectly()
        {
            Tensor3.Tensor3 tensor1 = new Tensor3.Tensor3(2, 2, 2);
            Tensor3.Tensor3 tensor2 = new Tensor3.Tensor3(2, 2, 2);
            tensor1.Fill(1);
            tensor2.Fill(2);

            Tensor3.Tensor3 result = tensor1.AddNew(tensor2);

            for (int i = 0; i < result.GetSize()[0] * result.GetSize()[1] * result.GetSize()[2]; i++)
            {
                Assert.AreEqual(3, result.GetElement(i % result.GetSize()[0], (i / result.GetSize()[0]) % result.GetSize()[1], i / (result.GetSize()[0] * result.GetSize()[1])));
            }
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void Tensor3_AddNew_DifferentSize_ThrowsException()
        {
            Tensor3.Tensor3 tensor1 = new Tensor3.Tensor3(2, 2, 2);
            Tensor3.Tensor3 tensor2 = new Tensor3.Tensor3(3, 3, 3);
            tensor1.Fill(1);
            tensor2.Fill(2);

            Tensor3.Tensor3 result = tensor1.AddNew(tensor2);

            for (int i = 0; i < result.GetSize()[0] * result.GetSize()[1] * result.GetSize()[2]; i++)
            {
                Assert.AreEqual(3, result.GetElement(i % result.GetSize()[0], (i / result.GetSize()[0]) % result.GetSize()[1], i / (result.GetSize()[0] * result.GetSize()[1])));
            }
        }

        [TestMethod]
        public void TestFill()
        {
            int sizeX = 3;
            int sizeY = 3;
            int sizeZ = 3;
            float value = 10.0f;
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(sizeX, sizeY, sizeZ);

            tensor.Fill(value);

            for (int x = 0; x < sizeX; x++)
            {
                for (int y = 0; y < sizeY; y++)
                {
                    for (int z = 0; z < sizeZ; z++)
                    {
                        Assert.AreEqual(value, tensor.GetElement(x, y, z));
                    }
                }
            }
        }

        [TestMethod]
        public void TestInitialization()
        {
            int sizeX = 3;
            int sizeY = 3;
            int sizeZ = 3;

            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(sizeX, sizeY, sizeZ);

            Assert.IsNotNull(tensor);
            Assert.AreEqual(sizeX, tensor.GetSize()[0]);
            Assert.AreEqual(sizeY, tensor.GetSize()[1]);
            Assert.AreEqual(sizeZ, tensor.GetSize()[2]);
        }

        [TestMethod]
        public void TestPrintZValuesAtXY()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(3, 3, 3);
            tensor.SetElement(0, 0, 0, 10);
            tensor.SetElement(0, 0, 1, 5);
            tensor.SetElement(0, 0, 2, 0);

            int x = 0;
            int y = 0;
            string expectedOutput = "Z values at X = 0, Y = 0: 10 5 0";

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            tensor.PrintZValuesAtXY(x, y);
            string actualOutput = consoleOutput.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestPrintYValuesAtXZ()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(3, 3, 3);
            tensor.SetElement(0, 0, 0, 10);
            tensor.SetElement(0, 1, 0, 5);
            tensor.SetElement(0, 2, 0, 0);

            int x = 0;
            int z = 0;

            string expectedOutput = "Y values at X = 0, Z = 0: 10 5 0";

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            tensor.PrintYValuesAtXZ(x, z);
            string actualOutput = consoleOutput.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);

        }

        [TestMethod]
        public void TestPrintXValuesAtYZ()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(3, 3, 3);
            tensor.SetElement(0, 0, 0, 10);
            tensor.SetElement(1, 0, 0, 5);
            tensor.SetElement(2, 0, 0, 0);

            int y = 0;
            int z = 0;

            string expectedOutput = "X values at Y = 0, Z = 0: 10 5 0";

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            tensor.PrintXValuesAtYZ(y, z);
            string actualOutput = consoleOutput.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestClearData()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.Fill(5);
        
            tensor.ClearData();

            CollectionAssert.AreEqual(new float[] { 0, 0, 0, 0, 0, 0, 0, 0 }, tensor.GetData());
        }

        [TestMethod]
        public void TestInnerArrayZero()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.Fill(5);

            tensor.InnerArrayZero();

            CollectionAssert.AreEqual(new float[] {}, tensor.GetData());
        }

        [TestMethod]
        public void TestPrintData()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.Fill(5);

            string expectedOutput = "Inner array: 5, 5, 5, 5, 5, 5, 5, 5,";

            var consoleOutput = new StringWriter();
            Console.SetOut(consoleOutput);

            tensor.PrintData();

            string actualOutput = consoleOutput.ToString().Trim();

            Assert.AreEqual(expectedOutput, actualOutput);
        }

        [TestMethod]
        public void TestScalarMultiply()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.Fill(5); 

            tensor.ScalarMultiply(2);

            CollectionAssert.AreEqual(new float[] { 10, 10, 10, 10, 10, 10, 10, 10 }, tensor.GetData());
        }

        [TestMethod]
        public void TestScalarMultiplyNew()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.Fill(5); 

            Tensor3.Tensor3 scaledTensor = tensor.ScalarMultiplyNew(2.1f);

            CollectionAssert.AreEqual(new float[] { 10.5f, 10.5f, 10.5f, 10.5f, 10.5f, 10.5f, 10.5f, 10.5f }, scaledTensor.GetData());
        }

        [TestMethod]
        public void TestGetMaxElement()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.SetElement(0, 0, 0, 5);
            tensor.SetElement(1, 1, 1, 10);

            float maxElement = tensor.GetMaxElement();

            Assert.AreEqual(10, maxElement);
        }

        [TestMethod]
        public void TestGetMinElement()
        {
            Tensor3.Tensor3 tensor = new Tensor3.Tensor3(2, 2, 2);
            tensor.SetElement(0, 0, 0, 5);
            tensor.SetElement(1, 1, 1, 10);

            float minElement = tensor.GetMinElement();

            Assert.AreEqual(0, minElement);
        }
    }
}
