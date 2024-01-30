using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

public class Test
{
    [Test]
    public void ShouldVerifyItemsExistsAndReturnTrue()
    {
        int[] codes = new int[20];
        codes[0] = 0;
        codes[1] = 1;
        int[] quantites = new int[20];
        quantites[0] = 10;
        quantites[1] = 20;
        Inventory inventory = new Inventory(codes, quantites);
        int[] passedCodes = { 0, 1 };
        int[] passedQuantities = { 10, 20 };
        bool result = inventory.verifyItemsExistence(passedCodes, passedQuantities);

        Assert.AreEqual(true, result);
    }

    [Test]
    public void ShouldVerifyItemsExistsAndReturnFalse()
    {
        int[] codes = new int[20];
        codes[0] = 0;
        codes[1] = 1;
        int[] quantites = new int[20];
        quantites[0] = 10;
        quantites[1] = 10;
        Inventory inventory = new Inventory(codes, quantites);
        int[] passedCodes = { 0, 1 };
        int[] passedQuantities = { 10, 20 };
        bool result = inventory.verifyItemsExistence(passedCodes, passedQuantities);

        Assert.AreEqual(false, result);
    }

    [UnityTest]
    public IEnumerator TestWithEnumeratorPasses()
    {

        yield return null;
    }
}
