FROM openshift/base-centos7
# Dockerfile for a database backup pod.

# install PostgreSQL client programs
RUN yum -y install postgresql

WORKDIR /
copy backup.sh .

RUN chown -R 1001:0 /backup.sh && chmod -R ug+rwx /backup.sh
USER 1001

ENTRYPOINT ["/backup.sh"]