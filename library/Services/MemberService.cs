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
/// <summary>
/// Pobiera wszystkich użytkowników z bazy
/// </summary>
/// <returns>Kolekcja encji typu użytkownik</returns>
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
                Fine = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                IsBanned = reader.GetBoolean(5)
            });
        }

        return result;
    }
    /// <summary>
    /// Dodaje nowego użytkownika poprzez rejestracje
    /// </summary>
    /// <param name="memberDto">Obiekt transferu danych dla użytkownika</param>
    /// <param name="registerDto">Obiekt transferu danych dla danych logowania</param>
    /// <returns>Zwraca "OK" w przypadku powodzenia</returns>
    /// <exception cref="NpgsqlException">W przypadku niepowodzenia rzucany jest wyjątek</exception>
    public async Task<string> AddNewMember(MemberDto memberDto, RegisterDto registerDto)
    {
        var command = new NpgsqlCommand(
            $"SELECT dodaj_uzytkownika('{registerDto.Username}', '{registerDto.Password}'," +
            $" '{memberDto.FirstName}','{memberDto.LastName}', {memberDto.IsStaff});", _dbContext.GetConnection());
        var res = await command.ExecuteScalarAsync() ?? throw new NpgsqlException("Something went wrong.");
        return (string) res;
    }
    /// <summary>
    /// Logowanie do serwisu
    /// </summary>
    /// <param name="registerDto">Obiekt transferu danych dla danych logowania</param>
    /// <returns>Użytkownik o podanych danych logowania</returns>
    /// <exception cref="NpgsqlException">W przypadku niepowodzenia rzuca wyjątek</exception>
    public async Task<Member?> Login(RegisterDto registerDto)
    {
        var command = new NpgsqlCommand($"SELECT uzytkownik_id FROM login WHERE login = '{registerDto.Username}' AND haslo = '{registerDto.Password}'",
            _dbContext.GetConnection());
        var id = await command.ExecuteScalarAsync() ?? throw new NpgsqlException("Could not get user");
        return GetMemberById((int)id);
    }
    /// <summary>
    /// Pobiera użytkownika o podanym ID
    /// </summary>
    /// <param name="memberId">ID użytkownika</param>
    /// <returns>Użytkownik o podanym ID</returns>
    public Member? GetMemberById(int memberId)
    {
        var command = new NpgsqlCommand($"SELECT * FROM uzytkownicy WHERE uzytkownik_id = {memberId}",
            _dbContext.GetConnection());
        using var reader = command.ExecuteReader();
        while(reader.Read())
        {
            return new Member()
            {
                Id = reader.GetInt32(0),
                FirstName = reader.GetString(1),
                LastName = reader.GetString(2),
                IsStaff = reader.GetBoolean(3),
                Fine = reader.IsDBNull(4) ? 0 : reader.GetDecimal(4),
                IsBanned = reader.GetBoolean(5)
            };
        }

        return null;
    }
}