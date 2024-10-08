#include <boost/asio.hpp>
using boost::asio::ip::tcp;

void server() {
    boost::asio::io_service io_service;
    tcp::acceptor acceptor(io_service, tcp::endpoint(tcp::v4(), 12345));

    for (;;) {
        tcp::socket socket(io_service);
        acceptor.accept(socket);
        // Procesar la conexión entrante (Leer/Escribir a la caché)
    }
}
