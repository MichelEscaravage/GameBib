using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace GameBib.Migrations
{
    /// <inheritdoc />
    public partial class GiveUserRole : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "7fEF1/Rivm1DzLAAAHpLG0P75OVo9QlCJHinlRXttB4=:zrSw/7N2u5Uix9MFrPPqoA==:10000:SHA512", new DateTime(2024, 12, 4, 13, 24, 4, 17, DateTimeKind.Local).AddTicks(1864), "LBM5npo2FY" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "HVmabCMtFrZiiV1SsMppebNnGcLLiDBi9HmrstpXk7A=:nj8w/b7Sl9MWBvDs4u01Ug==:10000:SHA512", new DateTime(2024, 12, 5, 8, 24, 4, 22, DateTimeKind.Local).AddTicks(7193), "1imB0TjIkW" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 3,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "dk2UiqviyaitlMRy6UbSUcyJScts9el0MoUTkt6QLvk=:XR4ubIGmOZyg8zD1IgevWg==:10000:SHA512", new DateTime(2024, 12, 3, 13, 24, 4, 28, DateTimeKind.Local).AddTicks(3191), "2uAy2VJ4yJ" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 4,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "rEWYBUi7CFLEvCbKLEi681Y5kzy28VTBp9q369Y2x1Q=:nnK8r/IjqAb1bcWPVQLtuw==:10000:SHA512", new DateTime(2024, 12, 5, 12, 54, 4, 34, DateTimeKind.Local).AddTicks(534), "iJxLcFUQOA" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 5,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "Hvqwbl4pNTUTMyu1Y7rLAobJz9IRcZzXp9VtHFOAX6c=:hamW/N9EcZSBfnNAGtyRUw==:10000:SHA512", new DateTime(2024, 12, 5, 3, 24, 4, 39, DateTimeKind.Local).AddTicks(6636), "eXsusHdViJ" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 6,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "SD95JdwLyzl8Pn+d+4HdMgZXBejS5LcGDjWTeLeO7OI=:7apqyiRSaA93uSWTSUVpzg==:10000:SHA512", new DateTime(2024, 12, 2, 13, 24, 4, 45, DateTimeKind.Local).AddTicks(2887), "Hd4fOwKHwO" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 7,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "+MdF/OYxp1wfEeFp6zNK9+3XwTGSMeS7c/RHBCd9Jos=:nLkhm9jtqE0rrr2nNjl+Fg==:10000:SHA512", new DateTime(2024, 12, 5, 5, 24, 4, 50, DateTimeKind.Local).AddTicks(9474), "hioP6aJDdb" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 8,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "79U/ZsIIuCEl0lLYoEwikOJcrb1LPqD4eyolgUkgurc=:bWKsjkXAg9mGxKyJXE5O3w==:10000:SHA512", new DateTime(2024, 11, 28, 13, 24, 4, 56, DateTimeKind.Local).AddTicks(5737), "LNBqymlKt1" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 9,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "sOV74XNc0oex7W0pqGpzCxt73ctB1/SAimPrJwun3/g=:u+YYz0ZmPHu6wrc/MXYQkg==:10000:SHA512", new DateTime(2024, 11, 21, 13, 24, 4, 62, DateTimeKind.Local).AddTicks(2053), "2UFrYtZ153" });

            migrationBuilder.UpdateData(
                table: "User",
                keyColumn: "Id",
                keyValue: 10,
                columns: new[] { "HashedPassword", "LastFailedLogin", "RememberToken" },
                values: new object[] { "OULP/qFxFg18A13MvHo25EGItfxRFK065TLSAHeHEoI=:BYDEfEyhTXKHyOy83juciQ==:10000:SHA512", new DateTime(2024, 12, 4, 10, 24, 4, 67, DateTimeKind.Local).AddTicks(9768), "n9S5hWQD6B" });
        }
    }
}
