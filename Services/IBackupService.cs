namespace HESDashboard.Services;

public interface IBackupService {
    Task<Byte[]> GenerateBackupAsJsonAsync();
}
