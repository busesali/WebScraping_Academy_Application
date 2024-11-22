<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="WebApplication7.WebForm1" %>

<!DOCTYPE html>
<html lang="tr">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Google Akademik Arama</title>
    <link rel="stylesheet" href="https://stackpath.bootstrapcdn.com/bootstrap/4.5.2/css/bootstrap.min.css">
    <style>
        /* Genel sayfa stilini ayarla */
        body {
            font-family: Arial, sans-serif;
            background-color: #ffecd9; /* Hafif turuncu arka plan rengi */
            margin: 0;
            padding: 0;
        }
        /* Logo'nun boyutunu ve ortalamasını ayarla */
        .google-logo {
            display: block; /* Resmi blok element olarak ayarlayarak, sağa ve sola yaslanmasını engeller */
            margin: 60px auto 30px auto; /* Resmi yatay olarak ortalar ve yukarıdan 60px aşağı kaydırır */
            width: 400px; /* İstediğiniz genişliği ayarlayabilirsiniz */
            height: auto; /* Boyutları orijinal oranlarına göre ayarlamak için */
            border-radius: 50%; /* Yuvarlak kenarlı bir görünüm sağlar */
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1); /* Hafif bir gölgelendirme ekler */
        }
        /* Arama formu stilini ayarla */
        .search-form {
            margin-top: 100px; /* Arama çubuğunu yukarıdan 30px aşağı kaydırır */
            text-align: center; /* Arama çubuğunu ortalar */
        }
        /* Arama çubuğu stilini ayarla */
        .form-control {
            height: 40px; /* Arama çubuğu yüksekliğini ayarla */
            font-size: 18px; /* Arama çubuğu metin boyutunu ayarla */
        }
        /* Arama butonu stilini ayarla */
        .btn-primary {
            height: 40px; /* Arama butonu yüksekliğini ayarla */
            padding: 0 20px; /* Arama butonu içeriğine yatay padding ekle */
            font-size: 18px; /* Arama butonu metin boyutunu ayarla */
        }
    </style>
</head>
<body>
    <!-- Sayfa içeriği -->
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <!-- Yeni Google Logo -->
                <img src="images/foto.jpeg" alt="Google Logo" class="google-logo">
                <!-- Arama Formu -->
                <form method="get" action="WebForm1.aspx" class="search-form">
                    <div class="input-group">
                        <input type="text" class="form-control" id="txtKeywords" name="keywords" placeholder="Anahtar kelimeleri girin...">
                        <div class="input-group-append">
                            <button type="submit" class="btn btn-primary">Ara</button>
                        </div>
                    </div>
                </form>
            </div>
        </div>
    </div>
</body>
</html>
