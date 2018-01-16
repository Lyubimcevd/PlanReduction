      INTEGER*2 A(26,200),S(2,200),P(2,200),TQ(6,500),TQC(4,500),NXZ(10,LMAT0004
     *4),ZAK(4,500),C,U(20,100)                                         LMAT0005
      INTEGER QZ(4,500),IW(100),UW(2,200)                               LMAT0006
      INTEGER*2 KDP(300)                                                LMAT0007
      DATA C/'99'/                                                      LMAT0008
   21 FORMAT(1X,'WI:')                                                  LMAT0009
   22 FORMAT(1X,12(I9,1X))                                              LMAT0010
      OPEN(2,FILE='f:\ASUIPw\tek_INF\U.DAT',FORM='UNFORMATTED')         TPOR0011
      READ(2) NW,NU                                                     TPOR0012
      READ(2) ((UW(I,J),I=1,2),J=1,NW),((U(I,J),I=1,20),J=1,NU)
1     FORMAT(40A2)                                                      LMAT0013
10    FORMAT('0A: NN  PTM   ND   **МАТЕРИАЛ**   **РАЗМЕРЫ***  NMK   NSS LMAT0014
     * QS   NSM  QO   NSP  QP    ПЭ    НАИМЕНОВАНИЕ ДЕТАЛИ')
101   format(1H ,17I5,5X
     *,10A2)                                                            LMAT0016
11    FORMAT(1H0,'S:  NN     NSA    QD',30X,'P:  N     NSA    QP')
111   format(1H ,I
     *6,2I7,30X,I6,2I7)                                                 LMAT0018
12    FORMAT('0 NN  TQ:    NSU   OЃ  SDS    DN    DK   DNS  QZ:    TP  LMAT0019
     *   PAC     QOЏ   QO     TQC:     DWO     Q     TAЃ       WI')
121   format(1H ,
     *I3,I11,5I6,I12,I8,I7,I10,I13,3I7)                                 LMAT0021
      WRITE(*,'('' задай номера заказов  '')')
      READ(*,1) ((ZAK(I,J),I=1,4),J=1,10)                               TPOR0022
      OPEN(1,FILE='f:\ASUIPw\tek_INF\PLAN.DAT',FORM='UNFORMATTED')
2     CONTINUE                                                          LMAT0023
3     READ(1,END=8) LP,NN,NK                                            LMAT0024
      WRITE(*,999) LP,NN,NK
  999 FORMAT(1X,3I8)
      LP1=LP*2                                                          LMAT0025
      READ(1) (KDP(I),I=1,LP1)                                          LMAT0026
4     READ(1) NXZ,(IW(I),I=1,NU),IQ,IP,ID,LD,LZ,LF,MP,MS,NA,NS,NT       LMAT0027
      IF(NA.LT.0) GOTO 8                                                LMAT0028
      READ(1) ((A(I,J),I=1,26),J=1,NA)                                  LMAT0029
      READ(1) ((S(I,J),I=1,2),J=1,NS),((P(I,J),I=1,2),J=1,NS)           LMAT0030
      READ(1) ((TQ(I,J),I=1,6),J=1,NT),((QZ(I,J),I=1,4),J=1,NT)         LMAT0031
      READ(1) ((TQC(I,J),I=1,4),J=1,NT)                                 LMAT0032
      DO 5 J=1,500                                                      LMAT0033
      IF(ZAK(1,J).EQ.C) GOTO 4                                          LMAT0034
      DO 6 I=1,4                                                        LMAT0035
      IF(NXZ(I,1).NE.ZAK(I,J)) GOTO 5                                   LMAT0036
6     CONTINUE                                                          LMAT0037
      GOTO 7                                                            LMAT0038
5     CONTINUE
 7    izap=1
      write(*,10)                                                       LMAT0039
      izap=izap+1
       if(izap.gt.22) pause 'Для продолжения нажми кл. "ENTER"' 
      if(izap.gt.22) izap=1
      DO 20 I=1,NA
      WRITE (*,101) I,(A(J,I),J=1,26)                                   TPOR0038
      izap=izap+2
       if(izap.gt.22) pause 'Для продолжения нажми кл. "ENTER"' 
      if(izap.gt.22) izap=1
 20   continue 
      pause 'Для продолжения нажми кл. "ENTER"'
      write(*,11)
      izap=izap+1
       if(izap.gt.22) pause 'Для продолжения нажми кл. "ENTER"' 
      if(izap.gt.22) izap=1
      DO 24 I=1,NS
      WRITE (*,111) I,(S(J,I),J=1,2),I,(P(J,I),J=1,2)                   TPOR0039
      izap=izap+1
       if(izap.gt.22) pause 'Для продолжения нажми кл. "ENTER"' 
      if(izap.gt.22) izap=1
  24  continue
      pause 'Для продолжения нажми кл. "ENTER"'
      write(*,12)
      izap=izap+1
       if(izap.gt.22) pause 'Для продолжения нажми кл. "ENTER"' 
      if(izap.gt.22) izap=1
      DO 25 I=1,NT
      WRITE (*,121) I,(TQ(J,I),J=1,6),(QZ(J,I),J=1,4),(TQC(J,I),J=1,4)
      izap=izap+2
       if(izap.gt.22) pause 'Для продолжения нажми кл. "ENTER"' 
      if(izap.gt.22) izap=1
  25  continue
      pause 'Для продолжения нажми кл. "ENTER"'
      IK=NU/12                                                          LMAT0044
      KI=NU-IK*12                                                       LMAT0045
      WRITE (*,21)                                                      LMAT0046
      L=1                                                               LMAT0047
      K=12                                                              LMAT0048
      DO 23 I=1,IK                                                      LMAT0049
      WRITE (*,22) (IW(J),J=L,K)                                        LMAT0050
      L=L+12                                                            LMAT0051
      K=K+12                                                            LMAT0052
   23 CONTINUE                                                          LMAT0053
      IF(KI.EQ.0) GOTO 40                                               LMAT0054
      WRITE (*,22) (IW(J),J=L,NU)                                       LMAT0055
   40 WRITE (*,13) ((NXZ(J,I),J=1,10),I=1,4),IQ,IP,LZ,ID,LF             LMAT0056
   13 FORMAT(1X,40A2,I5,2I3,I5,I3)                                      LMAT0057
      pause 'Для продолжения нажми кл. "ENTER"'
      GOTO 4                                                            LMAT0058
   8  STOP                                                              LMAT0060
      END                                                               LMAT0061