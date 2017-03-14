FROM openshift/base-centos7
# Dockerfile for a database backup pod.

# install PostgreSQL client programs
RUN yum install -y centos-release-scl && \
    INSTALL_PKGS="rsync tar gettext bind-utils rh-postgresql94 rh-postgresql94-libs gzip" && \
    yum -y --setopt=tsflags=nodocs install $INSTALL_PKGS && \
    rpm -V $INSTALL_PKGS && \
    yum clean all 

WORKDIR /
copy backup.sh .

RUN chown -R 1001:0 /backup.sh && chmod -R ug+rwx /backup.sh
USER 1001

ENTRYPOINT ["/backup.sh"]