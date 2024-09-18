set -e

# Esperar até que o MySQL esteja pronto
echo "Aguardando MySQL..."
 until dotnet ef database update --no-build; do
  >&2 echo "MySQL não está pronto. Tentando novamente em 5 segundos..."
  sleep 5
done

echo "Migrações aplicadas com sucesso. Iniciando a aplicação..."
exec dotnet ClienteAPI.dll