using FluentAssertions;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Sorts;
using Sorts.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAPI.Controllers;
using WebAPI.Data_Acces;
using Xunit;

namespace WebApiTests
{
    public class WebApiTests
    {
        private readonly Mock<IDbRepository> repositoryStub = new();
        [Fact]
        public async Task GetAllAsync_WithExistingData_ReturnsAllData()
        {
            var expectedItems = CreateTestItems();
            repositoryStub.Setup(repo => repo.GetAllAsync())
                .ReturnsAsync(expectedItems);
            var controller = new SortController(repositoryStub.Object, new SortService());

            var actionResult = await controller.GetAllAsync();
            var result = actionResult.Result as OkObjectResult;

            result.Value.Should().BeEquivalentTo(expectedItems);
        }
        [Fact]
        public async Task SortAsync_WithUnsortedArray_ReturnsSortedArray()
        {
            var arrayToSort = new int[] { 124124, 0, 0, -2, -5, 325, 0, 423, 1 };
            var sortedArray = new int[] { -5, -2, 0, 0, 0, 1, 325, 423, 124124 };
            var controller = new SortController(repositoryStub.Object, new SortService());

            var actionResult = await controller.SortAsync("InsertionSort", arrayToSort);
            var okResult = actionResult.Result as OkObjectResult;
            var result = okResult.Value as SortingResult;

            Assert.Equal(sortedArray, result.SortedArray);
        }

        private static IEnumerable<SortingResult> CreateTestItems()
        {
            return new List<SortingResult>
            {
                new SortingResult(){ Id = 1, SortName = "BubbleSort", StartArray = new int[] { 3, 1}, SortedArray = new int[] { 1, 3}, SortingTime = new TimeSpan(0, 0, 0, new Random().Next(86400)), RequestTime = DateTime.Now },
                new SortingResult(){ Id = 2, SortName = "InsertionSort", StartArray = new int[] { 1, 5, 3, 2}, SortedArray = new int[] { 1, 2, 3, 5 }, SortingTime = new TimeSpan(0, 0, 0, new Random().Next(86400)), RequestTime = DateTime.Now },
                new SortingResult(){ Id = 3, SortName = "MergeSort", StartArray = new int[] { 5, 1, 4, 2, 8}, SortedArray = new int[] { 1, 2, 4, 5, 8}, SortingTime = new TimeSpan(0, 0, 0, new Random().Next(86400)), RequestTime = DateTime.Now },
                new SortingResult(){ Id = 4, SortName = "BogoSort", StartArray = new int[] { -2, 1, 0, 47, 5, 6, -6}, SortedArray = new int[] { -6, -2, 0, 1, 5, 6, 47}, SortingTime = new TimeSpan(0, 0, 0, new Random().Next(86400)), RequestTime = DateTime.Now },
                new SortingResult(){ Id = 5, SortName = "SelectionSort", StartArray = new int[] { -1, -234, 0, 0, 2535325, 2342, 0, -43214, 5, 55}, SortedArray = new int[] { -43214, -234, -1, 0, 0, 0, 5, 55, 2342, 2535325}, SortingTime = new TimeSpan(0, 0, 0, new Random().Next(86400)), RequestTime = DateTime.Now }
            };
        }
    }
}
