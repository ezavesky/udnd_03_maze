#!/bin/sh

# http://blog.pkh.me/p/21-high-quality-gif-with-ffmpeg.html

palette="/tmp/palette.png"

filters="fps=15,scale=320:-1:flags=lanczos"
#ffmpeg -v warning -i $1 -vf "$filters,palettegen" -y $palette
#ffmpeg -v warning -i $1 -i $palette -lavfi "$filters [x]; [x][1:v] paletteuse" -y $2

# raw ffmpeg code
# ffmpeg -ss 0:1:35 -i Gameplay.mov -t 0:0:16 -s 770x434 -pix_fmt yuv420p -crf 20 -maxrate 1.2M  -bufsize 1000K -r 12  -filter:v "setpts=0.5*PTS" -gifflags +transdiff  Gameplay-banana.gif

# adapted code
#ffmpeg -ss "$2" -i "$1" -t "$3" -r 12  -filter:v "setpts=0.5*PTS" -vf "$filters,palettegen" -y $palette 
#ffmpeg -ss "$2" -i "$1" -i $palette -lavfi "$filters [x]; [x][1:v] paletteuse" -y -pix_fmt yuv420p -crf 20 -maxrate 1.2M  -s 770x434 -bufsize 1000K -r 12 -t "$3"  "$1.gif"

# 640x360
# 420x236
ffmpeg -ss "$2" -i "$1" -s 420x236 -r 4 -t "$3"  -f image2pipe -vcodec ppm - | convert -delay 12 - "$1.gif"


