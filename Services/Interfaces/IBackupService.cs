namespace HESDashboard.Services.Interfaces;

public interface IBackupService {
    Task<byte[]> GenerateBackupAsJsonAsync();
}
