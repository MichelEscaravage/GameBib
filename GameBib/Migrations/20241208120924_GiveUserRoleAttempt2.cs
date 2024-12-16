using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBib.Migrations
{
    /// <inheritdoc />
    public partial class GiveUserRoleAttempt2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "RoleId",
                table: "User",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "Gwi/sbPy6HgajnqjxB17tCQO4SNDC9bVpWFhO6f4tYY=:73T5CSNHg81Fz5yRtz17rw==:10000:SHA512", new DateTime(2024, 12, 7, 13, 9, 23, 744, DateTimeKind.Local).AddTicks(6844), "JJBDR1sUM1", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "Z5xBX59tB8CatcuY0s7sWzbIzlBWw1tR3e3yvD/pQGg=:M8p5HPyevMPF9oDMAMAJjA==:10000:SHA512", new DateTime(2024, 12, 8, 8, 9, 23, 750, DateTimeKind.Local).AddTicks(3163), "PjtIb2AMum", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "0eTArRxOAGyif/3SYGqbdvyCCOM6z/ql2pPr1rdSrTo=:qC3tSXb6odkgpH9YFb+Buw==:10000:SHA512", new DateTime(2024, 12, 6, 13, 9, 23, 756, DateTimeKind.Local).AddTicks(6448), "zgnPFdn82g", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "tmUcXeP29MMS0isxDXgoEOVip55oASnpdHCODuIsJq0=:dC7Y9ZK3osqxl644O2WZFQ==:10000:SHA512", new DateTime(2024, 12, 8, 12, 39, 23, 762, DateTimeKind.Local).AddTicks(6432), "Jkd1PqGpJQ", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "PDxcyHg1Yq++F01eHZsZUNmGIDR1kmaYTaqz74/AKDE=:cE6/ebTSOIYwaqrLC7o6Sw==:10000:SHA512", new DateTime(2024, 12, 8, 3, 9, 23, 768, DateTimeKind.Local).AddTicks(5585), "3tOLRt8Cz9", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "d1+7N9xBTl+E6SExujmeBqoXMvbocPt95bHdfTtNN58=:womQdCIBhPg55DX0OEdnzQ==:10000:SHA512", new DateTime(2024, 12, 5, 13, 9, 23, 774, DateTimeKind.Local).AddTicks(5434), "eBVYaIRcmt", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "bmGZGDKSi3fi+bSPzmNaPWBf5y5PBZHP4z9HswsLJTk=:CNhXD1uCoUTTaJgxzjZDWA==:10000:SHA512", new DateTime(2024, 12, 8, 5, 9, 23, 780, DateTimeKind.Local).AddTicks(1661), "o2JdmVs9na", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "EC/XUdDzYQRFMpbY8+lJwGMAFWQsaKoaaNh6wxZmys4=:1rYZqpe09HJB8OkhBJAPaw==:10000:SHA512", new DateTime(2024, 12, 1, 13, 9, 23, 786, DateTimeKind.Local).AddTicks(516), "YNycGpG8q7", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "zUVPR4Okvwo+wZHSeuTHmyGwRm46r5bDmMYExabfnm0=:A0gaW99RQqNI2TcrFdKkQw==:10000:SHA512", new DateTime(2024, 11, 24, 13, 9, 23, 791, DateTimeKind.Local).AddTicks(8620), "etzRlBSNwS", 0 });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken", "RoleId" },
                values: new object[] { "XyGQqrbQN0uIKyHXwENLI3l8d53KRyd2EExnanV5WXk=:xjTUtoGhic7PSHyM2NmTNw==:10000:SHA512", new DateTime(2024, 12, 7, 10, 9, 23, 797, DateTimeKind.Local).AddTicks(5058), "Rp5OEihKtu", 0 });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RoleId",
                table: "User");

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "hTSwo4NvamAXyfyJzmxrogRNH4z6RBSNelE6HLsZaDY=:UX2ct1A+95e0e1iaELmGeQ==:10000:SHA512", new DateTime(2024, 12, 7, 13, 0, 22, 938, DateTimeKind.Local).AddTicks(4249), "cs8QBLk4QN" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "p5vYtDRj/lPy4zlKXg9yHDj6PLTa+izdcG1JNR3DoK0=:3uQthBdSD+s098hCe9OUIA==:10000:SHA512", new DateTime(2024, 12, 8, 8, 0, 22, 944, DateTimeKind.Local).AddTicks(2995), "PlzMJefXvc" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "EKeBITJ1ii2o20mX5hQW6gdl0lTafQ1CoNztdmVUx4k=:uXvm6ayyGFeWcccF/mNl9Q==:10000:SHA512", new DateTime(2024, 12, 6, 13, 0, 22, 950, DateTimeKind.Local).AddTicks(5210), "eb9SOpiIdg" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "c58ZI8PhF00MpjYLMEfj9p27cbEuDhNrhXC4oS7kRTY=:uTrgerQockpFYv9Oml8QQA==:10000:SHA512", new DateTime(2024, 12, 8, 12, 30, 22, 956, DateTimeKind.Local).AddTicks(4203), "mZrj3jCclM" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "Tx5BqR5S/Icmw7hisgK2yZo0rqNXRO5Htve/LT8yQjo=:4ZK1o0SIVkj4Y8zzX3CLQA==:10000:SHA512", new DateTime(2024, 12, 8, 3, 0, 22, 962, DateTimeKind.Local).AddTicks(1071), "k2q49OS5ia" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "qyY0OKumyDHDVTpF93cDYuF8NCiYZ4P7S9mI5ir1lt8=:QFzTeJXkGOcft8etdc9aZw==:10000:SHA512", new DateTime(2024, 12, 5, 13, 0, 22, 967, DateTimeKind.Local).AddTicks(9015), "5KgMHDvES2" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "swAuLMmmByEQo7w1MwNFghSX/u/4Ci7Z5Q6l2H46e1E=:BOLokPD1s5BsQPyxxwhYgQ==:10000:SHA512", new DateTime(2024, 12, 8, 5, 0, 22, 974, DateTimeKind.Local).AddTicks(1222), "VieWlMeOiZ" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "xiPKPwkxed9vAVV/XamfF4wbXocOuZBMN0pGnlKQ7N4=:fk2s7xt4W9+/E8pX+BorXw==:10000:SHA512", new DateTime(2024, 12, 1, 13, 0, 22, 979, DateTimeKind.Local).AddTicks(8030), "hkHneBDnDs" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "+4Zp/CCtLcgNhj60c2aTQaE2+aay6mcEKRM62mX4Iws=:NE1jy/Km4Q4vLUDpaLg+iQ==:10000:SHA512", new DateTime(2024, 11, 24, 13, 0, 22, 985, DateTimeKind.Local).AddTicks(5344), "ySDhO7xvwv" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "tKOVQNfj68BpOuZAZ78NUH8IdWhfiJWaXyjmOUQWspc=:GBtExL/ph39sPAetBIiC0Q==:10000:SHA512", new DateTime(2024, 12, 7, 10, 0, 22, 991, DateTimeKind.Local).AddTicks(2422), "JXl9Ts4A2x" });
        }
    }
}
