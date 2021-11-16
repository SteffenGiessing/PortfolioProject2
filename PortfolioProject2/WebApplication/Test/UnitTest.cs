using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Xunit;
using Moq;

namespace WebApplication.Test
{
    public class UnitTest
    {
        private readonly Mock<IMapper> _mapperMock;
        private const int Port = 5000;
        [Fact]
        public void CheckConnection()
        {
            
        }
    }
}