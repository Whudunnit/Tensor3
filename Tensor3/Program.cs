using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Reflection.Emit;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Tensor3
{
    internal class Program
    {
        private static Tensor3 tensor;
        private static Tensor3 otherTensor;
        private static Tensor3 newTensor;
        private static Tensor3 sumTensor;
        private static Tensor3 scalarTensor;

        static void Main(string[] args)
        {
            int tensorChoice;
            int choice;
            do
            {
                Console.WriteLine(" 1. Create Tensor");
                Console.WriteLine(" 2. Set element");
                Console.WriteLine(" 3. Get element");
                Console.WriteLine(" 4. Add Tensor");
                Console.WriteLine(" 5. Add Tensor and get Sum Tensor");
                Console.WriteLine(" 6. Resize Tensor");
                Console.WriteLine(" 7. Fill Tensor");
                Console.WriteLine(" 8. Print Tensor size");
                Console.WriteLine(" 9. Print Tensor");
                Console.WriteLine("10. Print line along X, Y axes.");
                Console.WriteLine("11. Print line along X, Z axes.");
                Console.WriteLine("12. Print line along Y, Z axes.");
                Console.WriteLine("13. Delete Tensor data");
                Console.WriteLine("14. Set the size of the inner array to 0.");
                Console.WriteLine("15. Print inner array.");
                Console.WriteLine("16. Multiply the Tensor with a real number.");
                Console.WriteLine("17. Multiply the Tensor with a real number and get a new Scalar Tensor.");
                Console.WriteLine("18. Get max element.");
                Console.WriteLine("19. Get min element.");
                Console.WriteLine(" 0. Exit");

                Console.Write("Enter your choice: ");
                choice = int.Parse(Console.ReadLine());

                try
                {

                    switch (choice)
                    {
                        case 1:
                            
                            Console.Write("Enter size for x: ");
                            int sizeX = int.Parse(Console.ReadLine());
                            Console.Write("Enter size for y: ");
                            int sizeY = int.Parse(Console.ReadLine());
                            Console.Write("Enter size for z: ");
                            int sizeZ = int.Parse(Console.ReadLine());
                            tensor = new Tensor3(sizeX, sizeY, sizeZ);
                            Console.Write($"Tensor created with size ({sizeX}, {sizeY}, {sizeZ}) ");
                            Console.Write("Default filled value: 0");
                            break;
                        case 2:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                Console.Write("Enter x coordinate: ");
                                int x = int.Parse(Console.ReadLine());
                                Console.Write("Enter y coordinate: ");
                                int y = int.Parse(Console.ReadLine());
                                Console.Write("Enter z coordinate: ");
                                int z = int.Parse(Console.ReadLine());
                                Console.Write("Enter value: ");
                                float value = float.Parse(Console.ReadLine());
                                tensor.SetElement(x, y, z, value);
                                Console.WriteLine($"{x},{y},{z} set to {value}.");
                            }
                            else if (tensorChoice == 2)
                            {
                                Console.Write("Enter x coordinate: ");
                                int x = int.Parse(Console.ReadLine());
                                Console.Write("Enter y coordinate: ");
                                int y = int.Parse(Console.ReadLine());
                                Console.Write("Enter z coordinate: ");
                                int z = int.Parse(Console.ReadLine());
                                Console.Write("Enter value: ");
                                float value = float.Parse(Console.ReadLine());
                                sumTensor.SetElement(x, y, z, value);
                                Console.WriteLine($"{x},{y},{z} set to {value}.");
                            }
                            else if(tensorChoice == 3)
                            {
                                Console.Write("Enter x coordinate: ");
                                int x = int.Parse(Console.ReadLine());
                                Console.Write("Enter y coordinate: ");
                                int y = int.Parse(Console.ReadLine());
                                Console.Write("Enter z coordinate: ");
                                int z = int.Parse(Console.ReadLine());
                                Console.Write("Enter value: ");
                                float value = float.Parse(Console.ReadLine());
                                scalarTensor.SetElement(x, y, z, value);
                                Console.WriteLine($"{x},{y},{z} set to {value}.");
                            }
                            break;
                        case 3:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                Console.Write("Enter x coordinate: ");
                                int getX = int.Parse(Console.ReadLine());
                                Console.Write("Enter y coordinate: ");
                                int getY = int.Parse(Console.ReadLine());
                                Console.Write("Enter z coordinate: ");
                                int getZ = int.Parse(Console.ReadLine());
                                Console.WriteLine("Element at ({0}, {1}, {2}): {3}", getX, getY, getZ, tensor.GetElement(getX, getY, getZ));
                            }
                            else if (tensorChoice == 2)
                            {
                                Console.Write("Enter x coordinate: ");
                                int getX = int.Parse(Console.ReadLine());
                                Console.Write("Enter y coordinate: ");
                                int getY = int.Parse(Console.ReadLine());
                                Console.Write("Enter z coordinate: ");
                                int getZ = int.Parse(Console.ReadLine());
                                Console.WriteLine("Element at ({0}, {1}, {2}): {3}", getX, getY, getZ, sumTensor.GetElement(getX, getY, getZ));
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.Write("Enter x coordinate: ");
                                int getX = int.Parse(Console.ReadLine());
                                Console.Write("Enter y coordinate: ");
                                int getY = int.Parse(Console.ReadLine());
                                Console.Write("Enter z coordinate: ");
                                int getZ = int.Parse(Console.ReadLine());
                                Console.WriteLine("Element at ({0}, {1}, {2}): {3}", getX, getY, getZ, scalarTensor.GetElement(getX, getY, getZ));
                            }
                            break;
                        case 4:
                            Console.Write("Enter size for x: ");
                            int OtherSizeX = int.Parse(Console.ReadLine());
                            Console.Write("Enter size for y: ");
                            int OtherSizeY = int.Parse(Console.ReadLine());
                            Console.Write("Enter size for z: ");
                            int OtherSizeZ = int.Parse(Console.ReadLine());
                            otherTensor = new Tensor3(OtherSizeX, OtherSizeY, OtherSizeZ);
                            Console.Write("Enter value to fill: ");
                            float OtherFillValue = float.Parse(Console.ReadLine());
                            otherTensor.Fill(OtherFillValue);
                            tensor.Add(otherTensor);
                            Console.WriteLine("Tensors added.");
                            break;
                        case 5:
                            Console.Write("Enter size for x: ");
                            int NewSizeX = int.Parse(Console.ReadLine());
                            Console.Write("Enter size for y: ");
                            int NewSizeY = int.Parse(Console.ReadLine());
                            Console.Write("Enter size for z: ");
                            int NewSizeZ = int.Parse(Console.ReadLine());
                            newTensor = new Tensor3(NewSizeX, NewSizeY, NewSizeZ);
                            Console.Write("Enter value to fill: ");
                            float NewFillValue = float.Parse(Console.ReadLine());
                            newTensor.Fill(NewFillValue);
                            sumTensor = newTensor.AddNew(tensor);
                            Console.WriteLine("Sum Tensor created by adding tensors.");
                            break;
                        case 6:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                Console.Write("Enter new size for x: ");
                                int newX = int.Parse(Console.ReadLine());
                                Console.Write("Enter new size for y: ");
                                int newY = int.Parse(Console.ReadLine());
                                Console.Write("Enter new size for z: ");
                                int newZ = int.Parse(Console.ReadLine());
                                tensor.Resize(newX, newY, newZ);
                                Console.WriteLine("Tensor resized.");
                            }
                            else if (tensorChoice == 2)
                            {
                                Console.Write("Enter new size for x: ");
                                int newX = int.Parse(Console.ReadLine());
                                Console.Write("Enter new size for y: ");
                                int newY = int.Parse(Console.ReadLine());
                                Console.Write("Enter new size for z: ");
                                int newZ = int.Parse(Console.ReadLine());
                                sumTensor.Resize(newX, newY, newZ);
                                Console.WriteLine("Sum Tensor resized.");
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.Write("Enter new size for x: ");
                                int newX = int.Parse(Console.ReadLine());
                                Console.Write("Enter new size for y: ");
                                int newY = int.Parse(Console.ReadLine());
                                Console.Write("Enter new size for z: ");
                                int newZ = int.Parse(Console.ReadLine());
                                scalarTensor.Resize(newX, newY, newZ);
                                Console.WriteLine("Scalar Tensor resized.");
                            }
                            break;
                        case 7:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                Console.Write("Enter value to fill: ");
                                float fillValue = float.Parse(Console.ReadLine());
                                tensor.Fill(fillValue);
                                Console.WriteLine("Tensor filled with value: {0}", fillValue);
                            }
                            else if (tensorChoice == 2)
                            {
                                Console.Write("Enter value to fill: ");
                                float fillValue = float.Parse(Console.ReadLine());
                                sumTensor.Fill(fillValue);
                                Console.WriteLine("Sum Tensor filled with value: {0}", fillValue);
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.Write("Enter value to fill: ");
                                float fillValue = float.Parse(Console.ReadLine());
                                scalarTensor.Fill(fillValue);
                                Console.WriteLine("Scalar Tensor filled with value: {0}", fillValue);
                            }
                            break;
                        case 8:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                int[] size = tensor.GetSize();
                                Console.WriteLine("Tensor size: ({0}, {1}, {2})", size[0], size[1], size[2]);
                            }
                            else if (tensorChoice == 2)
                            {
                                int[] size = sumTensor.GetSize();
                                Console.WriteLine("Sum Tensor size: ({0}, {1}, {2})", size[0], size[1], size[2]);
                            }
                            else if (tensorChoice == 3)
                            {
                                int[] size = scalarTensor.GetSize();
                                Console.WriteLine("Scalar Tensor size: ({0}, {1}, {2})", size[0], size[1], size[2]);
                            }

                            break;
                        case 9:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                tensor.PrintAsMatrix();
                            }
                            else if (tensorChoice == 2)
                            {
                                sumTensor.PrintAsMatrix();
                            }
                            else if (tensorChoice == 3)
                            {
                                scalarTensor.PrintAsMatrix();
                            }
                            break;
                        case 10:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the X, Y axes.");
                                Console.Write("Enter x index: ");
                                int xCoordinate = int.Parse(Console.ReadLine());
                                Console.Write("Enter y index: ");
                                int yCoordinate = int.Parse(Console.ReadLine());
                                tensor.PrintZValuesAtXY(xCoordinate, yCoordinate);
                            }
                            else if (tensorChoice == 2)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the X, Y axes.");
                                Console.Write("Enter x index: ");
                                int xCoordinate = int.Parse(Console.ReadLine());
                                Console.Write("Enter y index: ");
                                int yCoordinate = int.Parse(Console.ReadLine());
                                sumTensor.PrintZValuesAtXY(xCoordinate, yCoordinate);
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the X, Y axes.");
                                Console.Write("Enter x index: ");
                                int xCoordinate = int.Parse(Console.ReadLine());
                                Console.Write("Enter y index: ");
                                int yCoordinate = int.Parse(Console.ReadLine());
                                scalarTensor.PrintZValuesAtXY(xCoordinate, yCoordinate);
                            }
                            break;
                        case 11:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if(tensorChoice == 1)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the X, Z axes.");
                                Console.Write("Enter x index: ");
                                int xCoordinate2 = int.Parse(Console.ReadLine());
                                Console.Write("Enter z index: ");
                                int zCoordinate = int.Parse(Console.ReadLine());
                                tensor.PrintYValuesAtXZ(xCoordinate2, zCoordinate);
                            }
                            else if (tensorChoice == 2)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the X, Z axes.");
                                Console.Write("Enter x index: ");
                                int xCoordinate2 = int.Parse(Console.ReadLine());
                                Console.Write("Enter z index: ");
                                int zCoordinate = int.Parse(Console.ReadLine());
                                sumTensor.PrintYValuesAtXZ(xCoordinate2, zCoordinate);
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the X, Z axes.");
                                Console.Write("Enter x index: ");
                                int xCoordinate2 = int.Parse(Console.ReadLine());
                                Console.Write("Enter z index: ");
                                int zCoordinate = int.Parse(Console.ReadLine());
                                scalarTensor.PrintYValuesAtXZ(xCoordinate2, zCoordinate);
                            }
                            break;
                        case 12:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if(tensorChoice == 1)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the Y, Z axes.");
                                Console.Write("Enter y index: ");
                                int yCoordinate2 = int.Parse(Console.ReadLine());
                                Console.Write("Enter z index: ");
                                int zCoordinate2 = int.Parse(Console.ReadLine());
                                tensor.PrintXValuesAtYZ(yCoordinate2, zCoordinate2);
                            }
                            else if(tensorChoice == 2)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the Y, Z axes.");
                                Console.Write("Enter y index: ");
                                int yCoordinate2 = int.Parse(Console.ReadLine());
                                Console.Write("Enter z index: ");
                                int zCoordinate2 = int.Parse(Console.ReadLine());
                                sumTensor.PrintXValuesAtYZ(yCoordinate2, zCoordinate2);
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.WriteLine("Enter the index of the line you want to print along the Y, Z axes.");
                                Console.Write("Enter y index: ");
                                int yCoordinate2 = int.Parse(Console.ReadLine());
                                Console.Write("Enter z index: ");
                                int zCoordinate2 = int.Parse(Console.ReadLine());
                                scalarTensor.PrintXValuesAtYZ(yCoordinate2, zCoordinate2);
                            }
                            break;
                        case 13:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                tensor.ClearData();
                                Console.WriteLine("Tensor cleared.");
                            }
                            else if (tensorChoice == 2)
                            {
                                sumTensor.ClearData();
                                Console.WriteLine("Sum Tensor cleared.");
                            }
                            else if (tensorChoice == 3)
                            {
                                scalarTensor.ClearData();
                                Console.WriteLine("Scalar Tensor cleared.");
                            }
                            break;
                        case 14:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                tensor.InnerArrayZero();
                                Console.WriteLine("Inner array of Tensor succesfully set to 0.");
                            }
                            else if(tensorChoice == 2)
                            {
                                sumTensor.InnerArrayZero();
                                Console.WriteLine("Inner array of Sum Tensor succesfully set to 0.");
                            }
                            else if (tensorChoice == 3)
                            {
                                scalarTensor.InnerArrayZero();
                                Console.WriteLine("Inner array of Scalar Tensor succesfully set to 0.");
                            }
                            break;
                        case 15:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                tensor.PrintData();
                            }
                            else if( tensorChoice == 2)
                            {
                                sumTensor.PrintData();
                            }
                            else if(tensorChoice == 3)
                            {
                                scalarTensor.PrintData();
                            }
                            break;
                        case 16:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if(tensorChoice == 1)
                            {
                                Console.Write("Enter a real number multiplier:");
                                float scalar = float.Parse(Console.ReadLine());
                                tensor.ScalarMultiply(scalar);
                                Console.WriteLine($"Tensor multiplied by {scalar}.");
                            }
                            else if(tensorChoice == 2)
                            {
                                Console.Write("Enter a real number multiplier:");
                                float scalar = float.Parse(Console.ReadLine());
                                sumTensor.ScalarMultiply(scalar);
                                Console.WriteLine($"Sum Tensor multiplied by {scalar}.");
                            }
                            break;
                        case 17:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if(tensorChoice == 1)
                            {
                                Console.Write("Enter a real number multiplier:");
                                float scalarNew = float.Parse(Console.ReadLine());
                                scalarTensor = tensor.ScalarMultiplyNew(scalarNew);
                                Console.WriteLine($"Tensor multiplied by {scalarNew}, values saved in Scalar Tensor.");
                            }
                            else if(tensorChoice == 2)
                            {
                                Console.Write("Enter a real number multiplier:");
                                float scalarNew = float.Parse(Console.ReadLine());
                                scalarTensor = sumTensor.ScalarMultiplyNew(scalarNew);
                                Console.WriteLine($"Sum Tensor multiplied by {scalarNew}, values saved in Scalar Tensor.");
                            }
                            break;
                        case 18:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if(tensorChoice == 1)
                            {
                                Console.Write("The max element of Tensor is: ");
                                tensor.GetMaxElement();
                            }
                            else if(tensorChoice == 2)
                            {
                                Console.Write("The max element of Sum Tensor is: ");
                                sumTensor.GetMaxElement();
                            }
                            else if(tensorChoice == 3)
                            {
                                Console.Write("The max element of Scalar Tensor is: ");
                                scalarTensor.GetMaxElement();
                            }
                            break;
                        case 19:
                            Console.Write("Enter your choice: 1 = Tensor, 2 = Sum Tensor, 3 = Scalar Tensor\n");
                            tensorChoice = int.Parse(Console.ReadLine());
                            if (tensorChoice == 1)
                            {
                                Console.WriteLine("The min element of Tensor is: ");
                                tensor.GetMinElement();
                            }
                            else if(tensorChoice == 2)
                            {
                                Console.WriteLine("The min element of Sum Tensor is: ");
                                sumTensor.GetMinElement();
                            }
                            else if (tensorChoice == 3)
                            {
                                Console.WriteLine("The min element of Scalar Tensor is: ");
                                scalarTensor.GetMinElement();
                            }
                            break;
                        case 0:
                            Console.WriteLine("Exiting...");
                            break;
                        default:
                            Console.WriteLine("Invalid choice.");
                            break;
                    }
                }
                catch (NullReferenceException)
                {
                    Console.WriteLine("A NullReferenceException occurred: Tensor does not exist, please create one first!");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Error: " + ex.Message);
                }
                Console.WriteLine();
            } while (choice != 0);
        }
    }
}

