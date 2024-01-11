using library.Database;
using library.DTOs;
using library.Entities;
using Npgsql;

namespace library.Services;

public class MemberService
{
    private readonly DbContext _dbContext;

    public MemberService(DbContext dbContext)
    {
        _dbContext = dbContext;
    }

    public ICollection<Member> GetAllMembers()
    {
        var command = new NpgsqlCommand("SELECT * FROM uzytkownicy;", _dbContext.GetConnection());
        var result = new List<Member>();
        using var reader = command.ExecuteReader();
        while (reader.Read())
        {
            result.Add(new Member()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                IsStaff = reader.GetBoolean(3),
                Fine = reader.GetDecimal(4),
                IsBanned = reader.GetBoolean(5)
            });
        }

        return result;
    }

    public async Task AddNewMember(MemberDto memberDto)
    {
        var command = new NpgsqlCommand($"INSERT INTO uzytkownicy(" +
                                        $"uzytkownik_imie, uzytkownik_nazwisko, czy_pracownik, kara, czy_zbanowany) " +
                                        $"VALUES ('{memberDto.FirstName}', '{memberDto.LastName}', '{memberDto.IsStaff}'" +
                                        $",0 , false);");
        await command.ExecuteNonQueryAsync();
    }

    public Member GetMemberById(int memberId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM uzytkownicy WHERE uzytkownik_id = {memberId}",
            _dbContext.GetConnection());
        using var reader = command.ExecuteReader();
        return new Member()
        {
            Id = reader.GetInt32(0),
            FirstName = reader.GetString(1),
            LastName = reader.GetString(2),
            IsStaff = reader.GetBoolean(3),
            Fine = reader.GetDecimal(4),
            IsBanned = reader.GetBoolean(5)
        };
    }
}