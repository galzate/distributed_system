import org.springframework.cache.annotation.Cacheable;
import org.springframework.stereotype.Service;

@Service
public class DataService {

    @Cacheable("cache")
    public String getData(String key) {
        // Lógica para obtener datos
        return "data";
    }
}
