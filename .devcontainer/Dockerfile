ARG VARIANT="6.0-focal"
FROM mcr.microsoft.com/vscode/devcontainers/dotnet:0-${VARIANT}

ARG NODE_VERSION="none"
RUN if [ "${NODE_VERSION}" != "none" ]; then su vscode -c "umask 0002 && . /usr/local/share/nvm/nvm.sh && nvm install ${NODE_VERSION} 2>&1"; fi

COPY mssql/installSQLtools.sh installSQLtools.sh
RUN bash ./installSQLtools.sh \
     && apt-get clean -y && rm -rf /var/lib/apt/lists/* /tmp/library-scripts

RUN dotnet dev-certs https
RUN dotnet tool install -g dotnet-ef
#RUN dotnet tool install -g Microsoft.dotnet-httprepl
ENV PATH $PATH:/root/.dotnet/tools
